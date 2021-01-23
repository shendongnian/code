        class LinkAndFileName
        {
            public LinkAndFileName(string initLink, string initFileName)
            {
                link = initLink;
                fileName = initFileName;
            }
            public string link { get; set; }
            public string fileName { get; set; }
        }
        private static Queue<LinkAndFileName> _items = new Queue<LinkAndFileName>();
        private static List<string> _results = new List<string>();
        static string dl_loc = "C:\\ProgramData\\jyrka98\\";
        public static void Start()
            {
                LinkAndFileName[] file_link_array = new []
                {
                    new LinkAndFileName("LINK1", "xvm_main_files.zip"),
                    new LinkAndFileName("LINK2", "jyrka98_xvm.zip"),
                    new LinkAndFileName("LINK3", "premium_hangar.zip"),
                    new LinkAndFileName("LINK4", "J1mB0_crosshair.zip"),
                    new LinkAndFileName("LINK5", "J1mB0_contour_icons_v1.zip"),
                    new LinkAndFileName("LINK6", "J1mB0_contour_icons_v2.zip"),
                    new LinkAndFileName("LINK7", "multiline_tank_carousel.zip"),
                    new LinkAndFileName("LINK8", "white_dead_tanks.zip"),
                };
                foreach (LinkAndFileName fileLink in file_link_array) { _items.Enqueue(fileLink); }
                DownloadItem();
            }
        private static void DownloadItem()
        {
            if (_items.Any())
            {
                LinkAndFileName nextItem = _items.Dequeue();
                WebClient WC = new WebClient();
                WC.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0");
                WC.DownloadFileCompleted += new AsyncCompletedEventHandler(WC_DownloadFileCompleted);
                WC.DownloadFileAsync(new Uri(nextItem.link), Path.Combine(dl_loc + nextItem.fileName));
                return;
            }
        }
        private static void WC_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadItem();
        }
