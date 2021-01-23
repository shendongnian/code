    <table>
        @if (@Model != null && @Model.Projects != null)
        {
    
            for (var i = 0; i < Model.Projects.Count; i++)
            {
                <tr>
                    <td>
                        @Html.Hidden("Projects[" + i + "].ProjectId", Model.Projects.ElementAt(i).ProjectId)
                        @Html.Label("Projects[" + i + "].ProjectName", Model.Projects.ElementAt(i).ProjectName)
                    </td>
                    <td>
                        @Html.TextBox("Projects[" + i + "].ProjectName", Model.Projects.ElementAt(i).ProjectName, new { @class = "form-control" })
                    </td>
                </tr>
            }
        }
    </table>
