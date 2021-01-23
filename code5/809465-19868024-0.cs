    bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.unobtrusive*"));
    
    @model Dashboard.Models.User
    @Scripts.Render("~/bundles/jqueryval")
    
    @using (Ajax.BeginForm("_UserInfo", "User", new AjaxOptions()
                            {
                                HttpMethod = "GET",
                                UpdateTargetId = "results",
                                InsertionMode = InsertionMode.Replace
                            }))
    {
    
        <fieldset>
        //...My Form 
    
            <p>
                <input type="submit" value="Find" />
            </p>
        </fieldset>
    }
    
    <div id="results">
    </div>
