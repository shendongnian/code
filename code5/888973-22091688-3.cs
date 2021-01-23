    @model MyViewModel
    @{
        ViewBag.Title = Model.PageTitle;
    }
    @foreach (var doc in Model.DocList)
    {
        <p>doc.Content</p>
    }
