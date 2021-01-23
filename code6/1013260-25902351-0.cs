    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Starting Send Mail Async Task");
            Task task = new Task(SendMessage);
            task.Start();
            Console.WriteLine("Update Database");
            UpdateDatabase();
    
            while (true)
            {
                // dummy wait for background send mail.
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    break;
                }
            }
    
        }
    
        public static async void SendMessage()
        {
            // Calls to TaskOfTResult_MethodAsync
            Task<bool> returnedTaskTResult = MailSenderAsync();
            bool result = await returnedTaskTResult;
    
            if (result)
            {
                UpdateDatabase();
            }
    
            Console.WriteLine("Mail Sent!");
        }
    
        private static void UpdateDatabase()
        {
            for (var i = 1; i < 1000; i++) ;
            Console.WriteLine("Database Updated!");
        }
    
        private static async Task<bool> MailSenderAsync()
        {
            Console.WriteLine("Send Mail Start.");
            for (var i = 1; i < 1000000000; i++) ;
            return true;
        }
    }
