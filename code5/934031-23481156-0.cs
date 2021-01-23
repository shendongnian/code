     @if (User.Identity.IsAuthenticated)
                     <li class="login-link">     {
      @Html.ActionLink(User.Identity.Name, "LogOff", "Account")
     </li>
    }
