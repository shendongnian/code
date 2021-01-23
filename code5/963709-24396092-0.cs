    @using (Html.BeginForm("Set", "UpdateRole", "Admin"))
    {
        @Html.HiddenFor(item.UserID);
        @Html.DropDownList(string.Format("User_{0}", item.UserID), ListProvider.GetRoles(roleId), new {  })
    }
