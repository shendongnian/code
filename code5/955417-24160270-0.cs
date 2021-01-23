    using System;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography;
    using System.Security.Cryptography.Pkcs;
    using System.IO;
 
    namespace Logue.Library.Cryptography
    {
    public static class CryptographyHelper
    {
        #region Public methods
        public static string Encrypt(string fullMessage, string certificateName)
        {
            X509Certificate2 certificate = GetCertificate(certificateName);
 
            string base64DecryptedContent = Convert.ToBase64String(Encoding.UTF8.GetBytes(fullMessage));
            base64DecryptedContent = ChunkContent(base64DecryptedContent, 76);
            base64DecryptedContent = EnvelopeBase64(base64DecryptedContent);
 
            byte[] contentBytes = Encoding.ASCII.GetBytes(base64DecryptedContent);
 
            Oid contentOid = new Oid("1.2.840.113549.1.7.1", "PKCS 7 Data");
            Oid algorithmOid = new Oid("1.2.840.113549.3.2", "rc2");
            AlgorithmIdentifier algorithmIdentifier = new AlgorithmIdentifier(algorithmOid);
            ContentInfo content = new ContentInfo(contentOid, contentBytes);
            EnvelopedCms envelope = new EnvelopedCms(SubjectIdentifierType.NoSignature, content, algorithmIdentifier);
 
            envelope.Encrypt(new CmsRecipient(certificate));
            byte[] encryptedBytes = envelope.Encode();
 
            string encryptedContent = Convert.ToBase64String(encryptedBytes);
 
            encryptedContent = ChunkContent(encryptedContent, 76);
            string result = EnvelopEncryptedContent(encryptedContent);
 
            return result;
        }
 
        public static string Decrypt(string fullMessage)
        {
            string messageContent = GetContentInBase64(fullMessage);
 
            // Load envelope and decrypt
            EnvelopedCms envelope = new EnvelopedCms();
            envelope.Decode(Convert.FromBase64String(messageContent));
            envelope.Decrypt();
 
            // Get original bytes
            byte[] decryptedBytes = envelope.ContentInfo.Content;
            string decryptedText = Encoding.ASCII.GetString(decryptedBytes);
 
            // Get processed Base64 content
            byte[] decryptedContentBytes = Convert.FromBase64String(GetContentInBase64(decryptedText));
            string decryptedContentText = Encoding.UTF8.GetString(decryptedContentBytes);
 
            return decryptedContentText;
        }
        #endregion
 
        #region Private Methods
        private static string ChunkContent(string encryptedContent, int chunkSize)
        {
            StringBuilder sb = new StringBuilder();
            StringReader sr = new StringReader(encryptedContent);
 
            int position = 0;
            char[] buffer = new char[chunkSize];
 
            while (position < encryptedContent.Length)
            {
                if (encryptedContent.Length - (position + chunkSize) < 0)
                chunkSize = encryptedContent.Length - position;
                sb.Append(encryptedContent.Substring(position, chunkSize));
                sb.Append("rn");
                position += chunkSize;
            }
 
            return sb.ToString();
        }
 
        private static string EnvelopEncryptedContent(string encryptedContent)
        {
            return CryptographyResources.ENCRYPTED_TEMPLATE.Replace("[REPLACE]", encryptedContent);
        }
 
        private static string EnvelopeBase64(string content)
        {
            return CryptographyResources.BASE64_TEMPLATE.Replace("[REPLACE]", content);
        }
 
        private static X509Certificate2 GetCertificate(string certificateName)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
            X509Certificate2 certificate = store.Certificates.Cast<X509Certificate2>().Where(cert => cert.Subject.IndexOf(certificateName) >= 0).FirstOrDefault();
            if (certificate == null)
            throw new Exception("Certificate " + certificateName + " not found.");
 
            return certificate;
        }
 
        private static string GetContentInBase64(string fullMessage)
        {
            string contentSeparator = Environment.NewLine + Environment.NewLine;
            int startIndex = fullMessage.IndexOf(contentSeparator) + contentSeparator.Length;
            int endIndex = fullMessage.Length - 1;
            StringBuilder sb = new StringBuilder();
            string[] lines = fullMessage.Substring(startIndex, endIndex - startIndex).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
            sb.Append(line);
            return sb.ToString();
        }
        #endregion
    }
    }
