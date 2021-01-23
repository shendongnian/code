    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonEncryptAttribute : Attribute
    {
    }
    public class EncryptedStringPropertyResolver : DefaultContractResolver
    {
        private byte[] encryptionKeyBytes;
        public EncryptedStringPropertyResolver(string encryptionKey)
        {
            if (encryptionKey == null)
                throw new ArgumentNullException("encryptionKey");
            // Hash the key to ensure it is exactly 256 bits long, as required by AES-256
            using (SHA256Managed sha = new SHA256Managed())
            {
                this.encryptionKeyBytes = 
                    sha.ComputeHash(Encoding.UTF8.GetBytes(encryptionKey));
            }
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // Find all string properties that have a [JsonEncrypt] attribute applied
            // and attach an EncryptedStringValueProvider instance to them
            foreach (JsonProperty prop in props.Where(p => p.PropertyType == typeof(string)))
            {
                PropertyInfo pi = type.GetProperty(prop.UnderlyingName);
                if (pi != null && pi.GetCustomAttribute(typeof(JsonEncryptAttribute), true) != null)
                {
                    prop.ValueProvider = 
                        new EncryptedStringValueProvider(pi, encryptionKeyBytes);
                }
            }
            return props;
        }
        class EncryptedStringValueProvider : IValueProvider
        {
            PropertyInfo targetProperty;
            private byte[] encryptionKey;
            public EncryptedStringValueProvider(PropertyInfo targetProperty, byte[] encryptionKey)
            {
                this.targetProperty = targetProperty;
                this.encryptionKey = encryptionKey;
            }
            // GetValue is called by Json.Net during serialization.
            // The target parameter has the object from which to read the unencrypted string;
            // the return value is an encrypted string that gets written to the JSON
            public object GetValue(object target)
            {
                string value = (string)targetProperty.GetValue(target);
                byte[] buffer = Encoding.UTF8.GetBytes(value);
                using (MemoryStream inputStream = new MemoryStream(buffer, false))
                using (MemoryStream outputStream = new MemoryStream())
                using (AesManaged aes = new AesManaged { Key = encryptionKey })
                {
                    byte[] iv = aes.IV;  // first access generates a new IV
                    outputStream.Write(iv, 0, iv.Length);
                    outputStream.Flush();
                    ICryptoTransform encryptor = aes.CreateEncryptor(encryptionKey, iv);
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        inputStream.CopyTo(cryptoStream);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());
                }
            }
            // SetValue gets called by Json.Net during deserialization.
            // The value parameter has the encrypted value read from the JSON;
            // target is the object on which to set the decrypted value.
            public void SetValue(object target, object value)
            {
                byte[] buffer = Convert.FromBase64String((string)value);
                using (MemoryStream inputStream = new MemoryStream(buffer, false))
                using (MemoryStream outputStream = new MemoryStream())
                using (AesManaged aes = new AesManaged { Key = encryptionKey })
                {
                    byte[] iv = new byte[16];
                    int bytesRead = inputStream.Read(iv, 0, 16);
                    if (bytesRead < 16)
                    {
                        throw new CryptographicException("IV is missing or invalid.");
                    }
                    ICryptoTransform decryptor = aes.CreateDecryptor(encryptionKey, iv);
                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputStream);
                    }
                    string decryptedValue = Encoding.UTF8.GetString(outputStream.ToArray());
                    targetProperty.SetValue(target, decryptedValue);
                }
            }
        }
    }
