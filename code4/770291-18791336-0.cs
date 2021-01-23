    var yourlist =new List<object>();
    foreach (var result in results) { 
        var descriptionlist=new List<stirng>();
        descriptionlist.Add("line1");
        descriptionlist.Add("line2");
        descriptionlist.Add("line3");
        yourlist.Add(new {
            id = result.id,
            description = descriptionlist
        });
    }
