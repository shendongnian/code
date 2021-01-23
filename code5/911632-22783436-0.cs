    @{
    List<Namspace.Models.Content> contents = ViewBag.data as List<Namspace.Models.Content>
    foreach(var item in contents)
    {
    <h2>@item.Title<h2>
    <p>@item.Content<p>
    }
    }
