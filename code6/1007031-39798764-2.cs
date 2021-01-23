    using( var context = new Context() ) {
        Link link    = context.Links.Where(x => x.Id == someId);
        bool isFirst = true;
        foreach( var id in userIds ) {
            if( isFirst ) {
                link.UserId = id;
                isFirst     = false;
            }
            else {
                string cloneString = JsonConvert.SerializeObject(link);
                Link clone = JsonConvert.DeserializeObject<Link>(cloneString);
                clone.UserId = id;
                context.Links.Add(clone);
            }
        }
        context.SaveChanges();
    }
