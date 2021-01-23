    <section id="socialLoginForm">
            @Html.Action("ExternalLoginsList",
    
                     new {ReturnUrl = ViewBag.ReturnUrl, IsRegistering=@ViewBag.IsRegistering })
        </section>
