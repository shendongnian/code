    @{
        var blogitems = Umbraco.Content("1188").Children.Where("Visible");
    
        foreach(var blog in blogitems) {
            var tagsplit = blog.tags.Split(',');
            var usedTags=new List<string>();
            foreach(var tag in tagsplit) {
                if(!usedTags.Contains(tag)){
                    <li>                    
                            <a href="/blog/?@tag">@tag</a>
                    </li>
                }
                usedTags.Add(tag);
            }
        }
    }
