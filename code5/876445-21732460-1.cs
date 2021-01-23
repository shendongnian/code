    <ul>
        <li id="L1" runat="server">
            <asp:HyperLink runat="server" ID="A1HyperLink" 
                NavigateUrl="~/newsFeed/allEr.aspx">
                <span>Er</span>
            </asp:HyperLink>
        </li>
    </ul>
    
    string url = Request.Url.PathAndQuery;
    string a1 = ResolveUrl(A1HyperLink.NavigateUrl);
    if (string.Equals(a1, url, StringComparison.InvariantCulture))
    {
        L1.Attributes.Add("class", "active");
    }
