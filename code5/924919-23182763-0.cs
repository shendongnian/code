    <p>
        @{
            Amity.Web.Models.UsersContext db = new Amity.Web.Models.UsersContext();   
        }
    </p>
    @foreach (var item in Model)
    {
     <div class="Comment-Box">
        <p>@item.UserId</p>
        @db.UserProfiles.FirstOrDefault(user => user.UserId == item.UserId).UserName
        @if (Membership.GetUser() != null)
            {
              if(User.IsInRole("Admin") || item.UserId == (int)Membership.GetUser().ProviderUserKey){
                    @Html.ActionLink("Delete", "DeleteComment", new { id=item.Id })
               }
            }
    </div>
    }
