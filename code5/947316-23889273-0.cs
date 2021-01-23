    class Program
    {
         public static List<Message> SearchBySource()
            {
            MessageHandler msg = new MessageHandler();
            List<Message> msgContent = msg.GetLatestMessages(1);
            return msgContent;
            }
         static void Main(string[] args)
         {
          List<Message> mymess =  SearchBySource();
            foreach (Message m in mymess) 
            {
            Console.WriteLine(m.Source);
            }
             Console.ReadLine();
         } 
