      static void Main(string[] args)
        {
            AnnouncementService announcementService = new AnnouncementService();
            announcementService.OnlineAnnouncementReceived += service_OnlineAnnouncementReceived;
            announcementService.OfflineAnnouncementReceived += service_OfflineAnnouncementReceived;
            using(var announcementServiceHost=new ServiceHost(announcementService))
            {
                announcementServiceHost.AddServiceEndpoint(new UdpAnnouncementEndpoint());
                announcementServiceHost.Open();
                Console.WriteLine("Please enter to exit\n\n");
                Console.ReadLine();
            }
        }
        static void service_OfflineAnnouncementReceived(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine("Service Offline");
        }
        static void service_OnlineAnnouncementReceived(object sender, AnnouncementEventArgs e)
        {
            Console.WriteLine("Service Online");
        }
