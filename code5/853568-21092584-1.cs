    @foreach (var Article in @Model.ContentList)
    {
         if(Article.Type == "Big")
         {
             <h1>@Article.Title</h1>
         }
         else if(Article.Type == "Medium")
         {
             <h2>@Article.Title</h2>
         }
         else if(Article.Type == "Small")
         {
             <h3>@Article.Title</h3>
         }
    }
