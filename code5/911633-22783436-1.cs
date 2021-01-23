    @{
    List<Namespace.Models.Content> contents = ViewBag.data as List<Namespace.Models.Content>
    foreach(var item in contents)
    {
    <h2>@item.Title<h2>
    <p>@item.Content<p>
    }
    }
