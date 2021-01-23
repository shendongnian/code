    <asp:ContentPlaceHolder runat="server" ID="PlaceHolder1">
        <ul class="nav navbar-nav">
        ...
    </asp:ContentPlaceHolder>
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated || Session["email"] != null)
        {
            PlaceHolder1.Visible = true;
        }
        else
        {
            PlaceHolder1.Visible = false;
        }
    }
