     public class Newss
            {
                public string News_Title { get; set; }
                public string News_Description { get; set; }
                public string Date_Start { get; set; }
                **//Edits**
                public string image_path {get;set}
                public BitmapImage ImageBind{get;set;}
            }
         foreach (var location in doc.Descendants("UserDetails"))
               {
                    Newss data = new Newss();
                    data.News_Title = location.Element("News_Title").Value;
                    data.Date_Start = location.Element("Date_Start").Value;
                    **//Edits**
                    data.image_path = location.Element("Image_Path").Value;
                    data.ImageBind = new BitmapImage(new Uri( @"http://political-leader.vzons.com/ArvindKejriwal/images/uploaded/"+data.image_path, UriKind.Absolute)
                    listData.Add(data);
                }
    
    **Your xaml changes**
    
        <Image Source="{Binding ImageBind }" />
