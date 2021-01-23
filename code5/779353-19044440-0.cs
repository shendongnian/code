    SPServiceCollection services = SPFarm.Local.Services;
            foreach(SPService curService in services)
            {
                if(curService is SPWebService)
                {
                    SPWebService webService = (SPWebService)curService;
                    foreach(SPWebApplication webApp in webService.WebApplications)
                    {
                        foreach(SPSite sc in webApp.Sites)
                        {
                            try
                            {
                                Console.WriteLine("Do something with site at: {0}", sc.Url);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("Exception occured: {0}\r\n{1}", e.Message, e.StackTrace);
                            }
                        }
                    }
                }
            }
