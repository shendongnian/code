    @model Example.User.Web.Models.UserModel
    
    
    @using (Html.BeginForm("Index", "User", "POST"))
    {
        <table>
            @{ int i = 0; }
            @foreach (var newitem in Model.SecurityGroups)
            {
                <tr>
                    <td>
                        @Html.CheckBoxFor(model => model.SecurityGroups[i].Active)
                        @Html.HiddenFor(model => model.SecurityGroups[i].Id, "Value")
                    </td>
                    <td>
                    @Html.DisplayFor(model => model.SecurityGroups[i].SecurityGroupName)
    
                </tr>
                i++;
            }
        </table>
        <input type="submit" name="btn1" value="Save" />
    }
