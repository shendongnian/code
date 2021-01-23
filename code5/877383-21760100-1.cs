    XmlDocument dataset = new XmlDocument();
    dataset.Load(@"C:\Users\Henry\AppData\Local\{9EC23EFD-F1A4-4f85-B9E9-
                   729CDE4EF4C7}\cache\DATA_RAINOBS\dataset.xml");
    App.Current.Dispatcher.Invoke((Action)delegate
    {
       _times.Clear();
       for (int x = 0; x < dataset.SelectNodes("//Times/Time").Count; x++)
       {
          _times.Add(
               new Time()
               {
                   Original = dataset.SelectNodes("//Times/Time/@original")
                                    [x].InnerText,
                   Display = dataset.SelectNodes("//Times/Time/@display")
                                    [x].InnerText,
                   Directory = dataset.SelectNodes("//Times/Time/@directory")
                                    [x].InnerText + "_LORES.png"
               });
       }
       _times.SelectedIndex = 0;
    });
