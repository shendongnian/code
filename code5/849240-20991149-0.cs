     void myClient_getarvindNewsCompleted(object sender, KejriwalService.getarvindNewsCompletedEventArgs e)
              {
    string result = e.Result.ToString();
     List<Newss> listData = new List<Newss>();
                XDocument doc = XDocument.Parse(result);
                // Just as an example of using the namespace...
                //var b = doc.Element("NewDataSet").Value;
                foreach (var location in doc.Descendants("UserDetails"))
                {
                    Newss data = new Newss();
                    data.News_Title = location.Element("News_Title").Value;
                    data.News_Description = location.Element("News_Description").Value;
                    data.News_Date_Start = location.Element("Date_Start").Value;
                    listData.Add(data);
                }
                  listBox1.ItemsSource = listData;
    
              }
