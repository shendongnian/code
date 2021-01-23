    @using (Html.BeginForm("CreateArticle", "Default"))
    {
        //form contolls here
        foreach (var item in Model)
        {
            @Html.DropDownListFor(modelItem => modelItem.TitleIds, new SelectList(ViewBag.TitleNames as System.Collections.IEnumerable, "TitleId", "Title.TitleText"), "No: " + (string)ViewBag.MagNo, new { id = "TitleIds" })
            break;
        }
        <button type="submit">submit</button>
    })
