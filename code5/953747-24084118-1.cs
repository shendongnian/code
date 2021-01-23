        class MainViewModel
        {
            public MainViewModel()
            {
                Channels = new ObservableCollection<Channel>();
            }
            public ObservableCollection<Channel> Channels { get; set; }
            public void fillTabs()
            {
                foreach (var log in infoLogParser.parsedLogs)
                {
                    Channel ch = Channels.FirstOrDefault(c => c.Name = "Channel " + log.data[2]);
                    if (ch == null)
                    {
                        ch = new Channel();
                        ch.Name = "Channel " + log.data[2];
                        Channels.Add(ch);
                    }
                    ch.Log.Add(log.data[4] + "\n");
                }
            }
        }
