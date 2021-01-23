    string html;
    using (LinQDataContext _DB = new LinQDataContext())
    {
    
        var urls = _DB.HotelImages.Where(o => o.ID_Hotel == Hotel_DA.ID_Hotel)
                   .Select(x => x.Url_Image);
    
        string builder = new StringBuilder();
        foreach (var url in urls)
        {
            builder.Append("<a href=''><img src='")
                   .Append(url)
                   .Append("'")
                   .Append("alt=''></a>");
        }
    }
    html = builder.ToString();
