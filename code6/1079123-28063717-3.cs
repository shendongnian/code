    @using System.Linq
    @using System.Data.Linq
    @inherits Umbraco.Web.Mvc.UmbracoTemplatePage
    @{
    var blogitems = Umbraco.Content("1102").Children.Where("Visible");
    <ul>
    @foreach(var blog in blogitems) {
        var tagsplit = blog.blogCats.Split(',').ToList();
        var usedTags=new List<string>();
        foreach(var tag in tagsplit.Take(5)) {
    
            //Output the first 5 items, then create a new <ul> and then list the rest
    
            if(!usedTags.Contains(tag)){
                <li>                    
                        <a href="/blog/?@tag">@tag</a>
                </li>
            }
            usedTags.Add(tag);
        }
    
        <a href="#" class="sort-item dropdown-toggle" data-toggle="dropdown">More <b class="caret"></b></a>
        <ul class="dropdown-menu">
        foreach(var tag in tagsplit.Skip(5)) {
           if(!usedTags.Contains(tag)){
                <li>                    
                        <a href="/blog/?@tag">@tag</a>
                </li>
           }
           usedTags.Add(tag);
        }
        </ul>
    }
    </ul>
 }
