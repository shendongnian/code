    @using (Html.BeginForm("Set", "UpdateRole", new { area="Admin"}, FormMethod.Get))
    {
        @Html.Hidden("userId", item.UserID);
        @Html.Hidden("roleId", roleId);
        @Html.DropDownList(string.Format("User_{0}", item.UserID), ListProvider.GetRoles(roleId), new {  })
    }
