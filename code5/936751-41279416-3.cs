        public static byte[] Serialize(Object _obj)
        {
            if (_obj == null)
                return null;
            byte[] Result = null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                bf.Serialize(memStream, _obj);
                Result = memStream.ToArray();
            }
            return Result;
        }
