    @model MVC.Controllers.MainViewModel
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    @using (Html.BeginForm("Submit", "Person", FormMethod.Post))
    {
    
        <table>
            @for (int i = 0 ; i < Model.Events.Count ; i++)
            {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => Model.Events[i].CompeditorID)
                        @Html.HiddenFor(modelItem => Model.Events[i].CompeditorID)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => Model.Events[i].Event_CompID)
                        @Html.HiddenFor(modelItem => Model.Events[i].Event_CompID)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => Model.Events[i].EventName)
                        @Html.HiddenFor(modelItem => Model.Events[i].EventName)
                    </td>
                </tr>
            }
        </table>
        <input type="submit" value="Save" />
    }
