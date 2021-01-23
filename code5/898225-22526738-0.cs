    @model IList<MvcApplication3.Models.CardModel>
    @using (Html.BeginForm("EditCard", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
    {
        for (int i = 0; i < Model.Count; i++) 
        {
            @Html.HiddenFor(m => Model[i].CardID)
            @Html.TextBoxFor(cardTitle => Model[i].CardTitle)
            <img src="@Model[i].CardFilePath" />
            <input type="file" name="files"> 
        }
        <br>
        <input type="submit" value="Upload File to Server">
    }
