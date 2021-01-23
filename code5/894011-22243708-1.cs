    private void PopulateList(XDocument doc)
        {
           List<Rest> restList = new List<Rest>();
            foreach (var location in doc.Descendants("UserDetails"))
            {
                Rest data = new Rest();
                data.restaurant_image = location.Element("restaurant_image").Value;
                data.ImageBind = new BitmapImage(new Uri(@" http://........" 
                                                 + data.restaurant_image, UriKind.Absolute));
                restList.Add(data);
    
            }
             ListBoxProduct.ItemSource = restList;
        }
