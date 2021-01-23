        class Program
    {
        TcpListener listener = new TcpListener(IPAddress.Any, 4456);
        NetworkStream stream;
        ObjectTypeUI ui;
        ObjectTypeDI di;
        ObjectTypeSI si;
        BinaryFormatter deserializer = new BinaryFormatter();
        public Program()
        {
         listener.Start();
         stream = listener.AcceptTcpClient().GetStream();
         while (true)
         {
             object streamObject = deserializer.Deserialize(stream);
             if (streamObject.GetType() == typeof(ObjectTypeSI))
             {
              si = (ObjectTypeSI)streamObject;
              Console.WriteLine(si.Kunde);
             }
             else if (streamObject.GetType() == typeof(ObjectTypeUI))
             {
              ui = (ObjectTypeUI)streamObject;
              Console.WriteLine(ui.CpuUsage);
             }
             else if(streamObject.GetType() == typeof(ObjectTypeDI))
             {
              di = (ObjectTypeDI)streamObject;
             }
         }
         
         
        }
        static void Main(string[] args)
        {
         new Program();
         Console.ReadLine();
        }
    }
