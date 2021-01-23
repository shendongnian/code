    @model Apps4KidsWeb.Models.AddAppViewModel
    
    @using Apps4KidsWeb.Domain
       
    <table>
        @foreach (KeyValuePair<int, int> item in Model.OperatingSystems)
        {
            <tr>
                <td>@operatingSystems[item.Value]</td>
                <td>
                    @Ajax.ActionLink(
                                            "Remove",
                                            "RemoveOperatingSystem",
                                            "Admin",
                                            new { guid = Model.Guid, id = item.Key },
                                            new AjaxOptions
                                            {
                                                HttpMethod = "POST",
                                                InsertionMode = InsertionMode.Replace,
                                                UpdateTargetId = "operatingSystems"
                                            })</td>
            </tr>
        }
    </table>
