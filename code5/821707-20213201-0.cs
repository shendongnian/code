    @model MvcApplication1.Models.MyClass
    @{
        ViewBag.Title = "Home";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    <h2>Home</h2>
    @using (Html.BeginForm())
    {
        @Html.TextBoxFor(m => m.Text)
    }
