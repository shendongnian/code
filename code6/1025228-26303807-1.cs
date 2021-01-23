      static void Main(string[] args)
            {
                Service1Client service1Client =  new Service1Client();
                 var result  = service1Client.GetData(5);
                if (result is SubItem)
                {
                    
                }
            }
