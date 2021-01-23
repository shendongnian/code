    ObservableCollection<Data> obs = new ObservableCollection<Data>();
            void MainPage_Loaded(object sender, RoutedEventArgs e)
            {
                obs.Add(new Data("Start", "Time :", "0"));
                lstData.ItemsSource = obs;
                LoadTimer();
            }
    
            public void LoadTimer()
            {
                int sec = 0;
                Timer timer = new Timer((obj) =>
                {
                    Dispatcher pageDispatcher = obj as Dispatcher;
    
                    pageDispatcher.BeginInvoke(() =>
                    {
                        sec++;
                        obs[0] = new Data("Changing", "Time :", sec.ToString());
                    });
    
                }, this.Dispatcher, 1000, 1000);
            }
    
            public class Data
            {
                public string Data1 { get; set; }
                public string Data2 { get; set; }
                public string Data3 { get; set; }
    
                public Data() { }
    
                public Data(string Data1, string Data2, string Data3)
                {
                    this.Data1 = Data1;
                    this.Data2 = Data2;
                    this.Data3 = Data3;
                }
            }
