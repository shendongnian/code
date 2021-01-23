    class WallModel
    {
        public WallModel()
        {
            WallItems = new ObservableCollection<Wall>();            
            Initialization = InitializeAsyn();
        }
        public Task Initialization { get; private set; }
        private async Taks InitializeAsyn()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("XXXXX");
            string Parse_Text = await response.Content.ReadAsStringAsync();
        }
        public ObservableCollection<Wall> WallItems { get; set; }
        }
    }
