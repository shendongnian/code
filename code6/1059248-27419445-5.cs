    InitializeComponent();
          
            List<KeyValuePair<DateTime, int>> llistaGastats = new List<KeyValuePair<DateTime, int>>();
            llistaGastats.Add(new KeyValuePair<DateTime, int>(DateTime.Now, 100));
            llistaGastats.Add(new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(1), 200));
            List<KeyValuePair<DateTime, int>> llistaPreu = new List<KeyValuePair<DateTime, int>>();
            llistaPreu.Add(new KeyValuePair<DateTime, int>(DateTime.Now, 300));
            llistaPreu.Add(new KeyValuePair<DateTime, int>(DateTime.Now.AddMonths(1), 300));
            var dataSourceList = new List<List<KeyValuePair<DateTime, int>>>();
            dataSourceList.Add(llistaGastats);
            dataSourceList.Add(llistaPreu);
            lineChart.DataContext = dataSourceList;
