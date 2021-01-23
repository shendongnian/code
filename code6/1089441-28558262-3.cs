    public class IAuthImplementation : IAuth
    {
        public IEnumerable<string> FindAccountsForService(string serviceId)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                string[] auths = store.GetFileNames("FieldStrikeMobile");
                foreach (string path in auths)
                {
                    using (var stream = new BinaryReader(new IsolatedStorageFileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, store)))
                    {
                        int length = stream.ReadInt32();
                        byte[] data = stream.ReadBytes(length);
                        byte[] unprot = ProtectedData.Unprotect(data, null);
                        yield return Encoding.UTF8.GetString(unprot, 0, unprot.Length);
                    }
                }
            }
        }
        public void Save(string pin, string serviceId)
        {
            byte[] data = Encoding.UTF8.GetBytes(pin);
            byte[] prot = ProtectedData.Protect(data, null);
            var path = GetAccountPath(serviceId);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var stream = new IsolatedStorageFileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, store))
            {
                stream.WriteAsync(BitConverter.GetBytes(prot.Length), 0, sizeof(int)).Wait();
                stream.WriteAsync(prot, 0, prot.Length).Wait();
            }
        }
        public void Delete(string serviceId)
        {
            var path = GetAccountPath(serviceId);
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                store.DeleteFile(path);
            }
        }
        private static string GetAccountPath(string serviceId)
        {
            return String.Format("{0}", serviceId);
        }
        public void CreateStore()
        {
            throw new NotImplementedException();
        }
    }
