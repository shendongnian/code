    @model MVC4.Models.DUPVM
    foreach (var item in Model.test)
    {
        @using (Html.BeginForm("Test1", "PDF", FormMethod.Post))
        {
            @Html.DisplayFor(modelitem => item.ID)
            <br>
            @Html.DisplayFor(modelitem => item.Rate)
            @Html.DisplayFor(modelitem => item.AgentID)
            @Html.TextBoxFor(modelitem => item.ID)
            <br>
            <input type="submit" value="Add to cart" />
            <br>
        }
    }
