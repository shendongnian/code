    var commonScripts = new List<string>()
    {
        "~/Content/Scripts/jQuery/jquery-2.1.1.js",
        "~/Content/Scripts/Bootstrap/bootstrap.js"
    };
    var homeScripts = new List<string>()
    {
      "~/Content/Scripts/Home.js"
    };
    bundles.Add(new ScriptBundle("~/bundles/home/")
                    .Include(commonScripts.Concat(homeScripts).ToArray()));
    var accountScripts = new List<string>()
    {
      "~/Content/Scripts/Account.js"
    };
    bundles.Add(new ScriptBundle("~/bundles/account/")
                    .Include(commonScripts.Concat(accountScripts).ToArray()));
