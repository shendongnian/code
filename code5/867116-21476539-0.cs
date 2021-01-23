    public class Newss
        {
            public string News_Title { get; set; }
            public string News_Description { get; set; }
            public string Date_Start { get; set; }
            public string Image_Path {get;set}
            public BitmapImage ImageBind{get;set;}
        }
     foreach (var location in doc.Descendants("UserDetails"))
           {
                Newss data = new Newss();
                data.News_Title = location.Element("News_Title").Value;
                data.Date_Start = location.Element("Date_Start").Value;
                data.Image_Path = location.Element("Image_Path").Value;
                data.ImageBind = new BitmapImage(new Uri( data.Image_Path, UriKind.Absolute)
                listData.Add(data);
            }
