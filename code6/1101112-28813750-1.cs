    using enterprise = NamespaceName.WebReferenceName;
    using proxy = System.Net.WebProxy;
    using System.Net;
    protected void Page_Load(object sender, EventArgs e)
    {
            enterprise.SforceService sforceService = new enterprise.SforceService();
            proxy wp = new proxy("StringOfHost", 9999); //Host, Port
            wp.Credentials = new NetworkCredentials("username", "password");
            sforceService.Proxy = wp;
            enterprise.LoginResult loginResult = sforceService.login(sfUsername, sfPwd);
    }
