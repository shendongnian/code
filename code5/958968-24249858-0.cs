    @model S2GPortal.Models.LoginModel
    
    
    <section id="featured">
        <h2>Use a local account to log in.</h2>
        @using (Html.BeginForm("Login", "Account", FormMethod.Post, new { ReturnUrl = ViewBag.ReturnUrl }))
            {
                @Html.AntiForgeryToken()
                @Html.ValidationSummary(true)
        
                <fieldset>
                    <legend>Log in Form</legend>
                    <ol>
                        <li>
                            @Html.LabelFor(m => m.UserName)
                            @Html.TextBoxFor(m => m.UserName)
                            @Html.ValidationMessageFor(m => m.UserName)
                        </li>
                        <li>
                            @Html.LabelFor(m => m.Password)
                            @Html.PasswordFor(m => m.Password)
                            @Html.ValidationMessageFor(m => m.Password)
                        </li>
                        <li>
                            @Html.CheckBoxFor(m => m.RememberMe)
                            @Html.LabelFor(m => m.RememberMe, new { @class = "checkbox" })
                        </li>
                    </ol>
                    <input type="submit" value="Log in" />
                </fieldset>
            }
        </section>
