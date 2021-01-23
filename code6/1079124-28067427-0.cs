    @using System.Linq
    @using System.Xml.Linq
    @inherits Umbraco.Web.Mvc.UmbracoTemplatePage
    @{
        var blogitems = Umbraco.Content("1102").Children.Where("Visible");
        <ul>
            @foreach (var blog in blogitems)
            {
                var tagsplit = blog.blogCats.Split(',');
                var usedTags = new List<string>();
    
                var i = 1;
                foreach (var tag in tagsplit)
                {
    
                    //Output the first 5 items, then create a new <ul> and then list the rest
                    if (i <= 5)
                    {
    
                        if (!usedTags.Contains(tag))
                        {
                            <li>
                                <a href="/blog/?@tag">@tag</a>
                            </li>
                        }
                        usedTags.Add(tag);
                        
                    }
                    i += 1;
                }
    
                <li><a href="#" class="sort-item dropdown-toggle" data-toggle="dropdown">More <b class="caret"></b></a></li>
                <ul>
    
                    @{
                        i = 1;
                        foreach (var tag in tagsplit)
                        {
                            if (i > 5)
                            {
    
                                if (!usedTags.Contains(tag))
                                {
                                    <li>
                                        <a href="/blog/?@tag">@tag</a>
                                    </li>
                                }
                                usedTags.Add(tag);
    
                                
                            }
    
                            i += 1;
                        }
                    }
                </ul>
            }
        </ul>
