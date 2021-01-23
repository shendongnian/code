        public static Object Deserialize(byte[] _arrBytes)
        {
            Object obj = null;
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(_arrBytes, 0, _arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                lock (assemblyResolveLocker)
                {
                    assemblyCmpt = 0;
                    AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                    obj = (Object)binForm.Deserialize(memStream);
                    AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                }
            }
            return obj;
        }
