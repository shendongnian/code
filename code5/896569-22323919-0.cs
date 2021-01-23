    using (NetworkStream sw = client.GetStream())
    {
         while (true)
         {
             byte[] message = Encoding.ASCII.GetBytes(Console.ReadLine());
             sw.Write(message, 0, message.Length);
             // Todo : Implement some kind of termination to the loop
         }
         sw.Flush();
     }
