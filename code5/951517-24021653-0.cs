       @for (int i = 0; i < Model.EditTables.Count; i++)
       {    
        <tr>
            <td>
                @Html.DisplayFor(modelItem => modelItem.EditTables[i].ID)
                @Html.HiddenFor(modelItem => Model.ID)
            </td>
        </tr>
        }
