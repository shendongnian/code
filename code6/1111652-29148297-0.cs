    // I added Async="true" to my aspx page
    <%@ Page Async="true"  Title="Async" Language="C#" CodeBehind="Async.aspx.cs" Inherits="Whatever"  %>
    // and then in my aspx.cs file await GetRolesAsync() works now
        public async Task LoadPage()
        {
            string userId = Request.Url.Segments[4];
            ApplicationUserManager manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IList<string> roles = await manager.GetRolesAsync(userId);
            if (roles.Count > 0) {
                PrivilegeList.SelectedValue = roles[0];
            }                   
        }
