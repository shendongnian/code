    Task.Factory.StartNew(() => 
    {
       NewWindow.selectingTab(ClientName); 
       using (var ns = cl.GetStream()) 
       using (var br = new BinaryReader(ns)) 
       using (var bw = new BinaryWriter(ns)) 
       { 
          Console.WriteLine("Message from client is " + br.ReadString() + " from " + clientName); } }); 
