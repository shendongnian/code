     XmlReader reader = XmlReader.Create(@"http://link1/myxaml.xml");
    SyndicationFeed feed = SyndicationFeed.Load(reader);
    var titles = from item in feed.Items
                select new
                    {
                    item.Title.Text,  
                     };
    var descriptions = from item in feed.Items
            select new
                {   
                item.Summary.Text
                 };
                
    foreach (var t in titles)
     {
    title_textbox.Text += t.Text + "  ";             //Your All Titles Here
    
     }
    foreach (var des in descriptions)
     {
    description_textbox.Text += des.Text + "  ";     //Your All Descriptions Here  
     }
