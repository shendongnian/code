        @using Microsoft.AspNet.Identity
        @if (Request.IsAuthenticated)
        {
            using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm" }))
            {
                 @Html.AntiForgeryToken()
                 // ...
                 <a href="javascript:document.getElementById('logoutForm').submit()">LogOff</a>
            }
        }
