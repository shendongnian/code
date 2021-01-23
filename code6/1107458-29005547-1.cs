    public class IAuthImplementation : IAuth
    {
        Context context;
        KeyStore ks;
        KeyStore.PasswordProtection prot;
    
        static readonly object fileLock = new object();
    
        const string FileName = "MyProg.Accounts";
        static readonly char[] Password = null;
    
        public void CreateStore()
        {
    
            this.context = Android.App.Application.Context;
    
            ks = KeyStore.GetInstance(KeyStore.DefaultType);
    
            prot = new KeyStore.PasswordProtection(Password);
    
            try
            {
                lock (fileLock)
                {
                    using (var s = context.OpenFileInput(FileName))
                    {
                        ks.Load(s, Password);
                    }
                }
            }
            catch (Java.IO.FileNotFoundException)
            {
                //ks.Load (null, Password);
                LoadEmptyKeyStore(Password);
            }
        }
    
        public IEnumerable<string> FindAccountsForService(string serviceId)
        {
            var r = new List<string>();
    
            var postfix = "-" + serviceId;
    
            var aliases = ks.Aliases();
            while (aliases.HasMoreElements)
            {
                var alias = aliases.NextElement().ToString();
                if (alias.EndsWith(postfix))
                {
                    var e = ks.GetEntry(alias, prot) as KeyStore.SecretKeyEntry;
                    if (e != null)
                    {
                        var bytes = e.SecretKey.GetEncoded();
                        var password = System.Text.Encoding.UTF8.GetString(bytes);
                        r.Add(password);
                    }
                }
            }
            return r;
        }
    
        public void Delete(string serviceId)
        {
            var alias = MakeAlias(serviceId);
    
            ks.DeleteEntry(alias);
            Save();
        }
    
        public void Save(string pin, string serviceId)
        {
            var alias = MakeAlias(serviceId);
    
            var secretKey = new SecretAccount(pin);
            var entry = new KeyStore.SecretKeyEntry(secretKey);
            ks.SetEntry(alias, entry, prot);
    
            Save();
        }
    
        void Save()
        {
            lock (fileLock)
            {
                using (var s = context.OpenFileOutput(FileName, FileCreationMode.Private))
                {
                    ks.Store(s, Password);
                }
            }
        }
    
        static string MakeAlias(string serviceId)
        {
            return "-" + serviceId;
        }
    
        class SecretAccount : Java.Lang.Object, ISecretKey
        {
            byte[] bytes;
            public SecretAccount(string password)
            {
                bytes = System.Text.Encoding.UTF8.GetBytes(password);
            }
            public byte[] GetEncoded()
            {
                return bytes;
            }
            public string Algorithm
            {
                get
                {
                    return "RAW";
                }
            }
            public string Format
            {
                get
                {
                    return "RAW";
                }
            }
        }
    
        static IntPtr id_load_Ljava_io_InputStream_arrayC;
    
        void LoadEmptyKeyStore(char[] password)
        {
            if (id_load_Ljava_io_InputStream_arrayC == IntPtr.Zero)
            {
                id_load_Ljava_io_InputStream_arrayC = JNIEnv.GetMethodID(ks.Class.Handle, "load", "(Ljava/io/InputStream;[C)V");
            }
            IntPtr intPtr = IntPtr.Zero;
            IntPtr intPtr2 = JNIEnv.NewArray(password);
            JNIEnv.CallVoidMethod(ks.Handle, id_load_Ljava_io_InputStream_arrayC, new JValue[]
                {
                    new JValue (intPtr),
                    new JValue (intPtr2)
                });
            JNIEnv.DeleteLocalRef(intPtr);
            if (password != null)
            {
                JNIEnv.CopyArray(intPtr2, password);
                JNIEnv.DeleteLocalRef(intPtr2);
            }
        }
