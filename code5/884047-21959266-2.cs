    @model MVC.Controllers.AdminViewModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    @using (Html.BeginForm("Submit", "Person", FormMethod.Post))
    {
    
        <table>
            @for (int i = 0; i < Model.UserList.Count; i++)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => Model.UserList[i].Id)
                        @Html.HiddenFor(modelItem => Model.UserList[i].Id)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => Model.UserList[i].FirstName)
                        @Html.HiddenFor(modelItem => Model.UserList[i].FirstName)
                    </td>
                    <td>
                        @Html.CheckBoxFor(modelItem => Model.UserList[i].IsAdmin)
                    </td>
                </tr>
            }
        </table>
        <input type="submit" value="Save" />
    }
