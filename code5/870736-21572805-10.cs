    @model ViewModel
    
    @{
        ViewBag.Title = "Comments";
    }
    @foreach(ImageComment comment in Model.ImageComments)
    {
        <p>@comment.Comment</p>
        <img src="@comment.ImageUrl" alt="img" />
    }
