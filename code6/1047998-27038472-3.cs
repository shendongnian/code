    using Client.LogInServiceReferenceForClient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Client
    {
        class Program
        {
            static void Main(string[] args)
            {
                LogInServiceReferenceForClient.UserClient client = new LogInServiceReferenceForClient.UserClient();
                User aUser = new User();
                aUser.UserName = Console.ReadLine();
                aUser.Password = Console.ReadLine();
                Console.WriteLine(client.ValidateUser(aUser).ToString());
                Console.ReadKey();
            }
        }
    }
