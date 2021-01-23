      public class Service1 : IService1
      {
        public string SaveFile(byte[] buffer, string fileName)
        {
            var fs = new FileStream(@"C://" + fileName, FileMode.Create, FileAccess.ReadWrite);            
            fs.Write(buffer, 0, (int)buffer.Length);
            fs.Close();           
            return "ok";
        }
     }
