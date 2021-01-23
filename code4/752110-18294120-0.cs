    <table class="table table-condensed">
        <thead>
            <tr>
                <th>#</th>
                <th>Benutzername</th>
                <th>Aktiviert</th>
                <th>S0Pin Ansicht</th>
                <th>Einstellungen</th>
                <th>Aktionen</th>
            </tr>
        </thead>
        <tbody>
            @if (Model != null && Model.Count > 0) {
                foreach (var item in Model) {
                <tr>
                    <td>@item.ID</td>
                    <td>@item.Username</td>
                    @if (item.Activated) {
                        <td><i id="active_@item.ID" class="icon-ok" /></td>
                    } else {
                        <td><i id="active_@item.ID" class="icon-remove" /></td>
                    }
                    @if (item.S0PinAllowed) {
                        <td><i id="support_@item.ID" class="icon-ok" /></td>
                    } else {
                        <td><i id="support_@item.ID" class="icon-remove" /></td>
                    }
                    @if (item.SettingsAllowed) {
                        <td><i id="settings_@item.ID" class="icon-ok" /></td>
                    } else {
                        <td><i id="settings_@item.ID" class="icon-remove" /></td>
                    }
                    <td>
                        @if (item.Username == User.Identity.Name) {
                            <span>Keine Aktionen verfügbar</span>
                        } else {
                            using (Ajax.BeginForm(item.Activated ? "DeactivateUser" : "ActivateUser", "Settings", new { username = item.Username }, new AjaxOptions() {
                                HttpMethod = "POST",
                                UpdateTargetId = "usertable"
                            }, new {
                                id = "formlogin_" + item.ID,
                            })) {
                                var user = item as Token.Creator.Site.Models.User;
                            @Html.Hidden("first", Model.First)
                            @Html.Hidden("count", Model.Fetch)
                                if (item.Activated) {
                            <input class="btn btn-danger btn-small pull-left" type="submit" id="sublogin_@item.ID" value="Deaktivieren" />
                                } else { 
                            <input class="btn btn-success btn-small pull-left" type="submit" id="sublogin_@item.ID" value="Aktivieren" />
                                }
                            }
                            using (Ajax.BeginForm(item.S0PinAllowed ? "DeactivateSupportUser" : "ActivateSupportUser", "Settings", new { username = item.Username }, new AjaxOptions() {
                                HttpMethod = "POST",
                                UpdateTargetId = "usertable"
                            }, new {
                                id = "formsupport_" + item.ID
                            })) {
                                var user = item as Token.Creator.Site.Models.User;
                            @Html.Hidden("first", Model.First)
                            @Html.Hidden("count", Model.Fetch)
                                if (item.S0PinAllowed) {
                            <input class="btn btn-danger btn-small pull-left" type="submit" id="subsupport_@item.ID" value="Support verweigern" />
                                } else { 
                            <input class="btn btn-success btn-small pull-left" type="submit" id="subsupport_@item.ID" value="Support erlauben" />
                                }
                            }
                            using (Ajax.BeginForm(item.SettingsAllowed ? "DeactivateSettingsUser" : "ActivateSettingsUser", "Settings", new { username = item.Username }, new AjaxOptions() {
                                HttpMethod = "POST",
                                UpdateTargetId = "usertable"
                            }, new {
                                id = "formsettings_" + item.ID
                            })) {
                                var user = item as Token.Creator.Site.Models.User;
                            @Html.Hidden("first", Model.First)
                            @Html.Hidden("count", Model.Fetch)
                                if (item.SettingsAllowed) {
                            <input class="btn btn-danger btn-small pull-left" type="submit" id="subsettings_@item.ID" value="Einstellungen verweigern" />
                                } else {
                            <input class="btn btn-success btn-small pull-left" type="submit" id="subsettings_@item.ID" value="Einstellungen erlauben" />
                                }
                            }
                        }
                    </td>
                </tr>
                }
            } else {
                <tr class="alert alert-info">
                    <td colspan="6">Leider sind keine Daten verfügbar :(</td>
                </tr>
            }
        </tbody>
    </table>
