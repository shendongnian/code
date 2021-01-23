    @foreach (var i = 0; i < Model.Count(); i++)
        {
            using (Html.BeginForm("Save", "Device"))
            {
                <tr>
                    <td style="background: alice;">
                        @Html.ValidationMessageFor(m => Model[i].Name)
                    </td>
                    <td>
                        @Html.TextBoxFor(modelItem => Model[i].Name)
                    </td>
                    <td>
                        @Html.ActionLink("Edit", "Edit", new { id = Model[i].Id }) |
                        @Html.ActionLink("Details", "Details", new { id = Model[i].Id }) |
                        @Html.ActionLink("Delete", "Delete", new { id = Model[i].Id })
                    </td>
                    <td>
                        <input type="submit" value="Save" />
                    </td>
                </tr>
            }
