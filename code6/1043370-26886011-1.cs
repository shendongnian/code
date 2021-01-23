    public static void Main()
    {
         var status=new ManageStatus();
         status.GetState();
         Console.Writline("State:{0}",status.State);
         Console.Writline("Up:{0}",status.Up);
         Console.Writline("Down:{0}",status.Down);
         Console.Writline("Process:{0}",status.Process);
    }
