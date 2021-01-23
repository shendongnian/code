     protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
            {
                if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
                {
                  FillPricesData();
                }
                base.OnNavigatedTo(e);
            }
    
     private void FillPricesData()
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCompletedEvent);
            client.DownloadStringAsync(new Uri("http://www.test.com/web/Prices.asmx/getdDat?Username=test1&Password=test123"));
    
        }
    
        private void DownloadStringCompletedEvent(object sender, DownloadStringCompletedEventArgs e)
        {
    
                if (e.Error != null)
                    return;
                XElement element = XElement.Parse(e.Result.ToString());
    
                List<Prices> prices = (from p in element.Descendants("Table")
                                       orderby (string)p.Element("category")
                                       select new Prices
                                       {
                                           category = (string)p.Element("category"),
                                           price = (string)p.Element("price"),
                                           //priceDate = (string)p.Element("priceDate")
                                       }).ToList<Prices>();
    
                lstAromaticsPrices.ItemsSource = prices;
    
        }
