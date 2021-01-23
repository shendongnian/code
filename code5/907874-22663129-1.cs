     void Main()
     {
         Socket s = new Socket(SocketType.Stream    , ProtocolType.Tcp);
         Task worker = DoWorkAsync(s);
         worker.Wait();
         s.Close();
         Console.ReadLine();
    }
    private async Task DoWorkAsync(Socket s){
         await s.ConnectTaskAsync( "127.0.0.1" , 443);
         await s.SendTaskAsync(Encoding.UTF8.GetBytes("hello"));
    }
