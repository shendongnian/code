    @using (Html.BeginForm("DliAction", "Dli", FormMethod.Post, new { id = "mainForm" }))
    {
        if (isOnDli)
        {
            <button name="removeDli" value="@result.WeNo">Remove From DLI</button>
        }
        else
        {
            <button name="performDli" value="@result.WeNo">Perform DLI</button>
        }
    }
