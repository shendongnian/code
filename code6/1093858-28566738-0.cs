    @if (Model.MyList.Count == 0)
    {
        @Html.Action("MyFunc", "MyController", new { MyData = Default.Value })
    }
    else
    {
        foreach(var Item in Model.MyList)
        {
            @Html.Action("MyFunc", "MyController", new { MyData = Item.Data })
        }
    }
