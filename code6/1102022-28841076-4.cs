    <!-- only one submit button -->
    @using (Html.BeginForm("actionName", "controllerName", new { sampleValue = 1 }, FormMethod.Post))
    {
        for (int i = 0; i < 10; i++)
        {
        @Html.TextBoxFor(x => x.NorthOrderDetails[i].UnitPrice)
        }
    
        <input type="submit" />
    }
    <!-- each row is one form -->
    @for (int i = 0; i < 10; i++)
    {
        using (Html.BeginForm("actionName", "controllerName", new { sampleValue = 1 }, FormMethod.Post))
        {
            @Html.TextBoxFor(x => x.NorthOrderDetails[i].UnitPrice)
            <input type="submit" />
        }
    }
