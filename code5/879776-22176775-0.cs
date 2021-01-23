    try
    {
        Uri baseUri = new Uri(txtURI.Text);
        Windows.Web.Http.Filters.HttpBaseProtocolFilter filter = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
        Windows.Web.Http.HttpCookie cookie = new Windows.Web.Http.HttpCookie("cookieName", baseUri.Host, "/");
        cookie.Value = "cookieValue";
        filter.CookieManager.SetCookie(cookie, false);
        Windows.Web.Http.HttpRequestMessage httpRequestMessage = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Get, baseUri);
        wvTest.NavigateWithHttpRequestMessage(httpRequestMessage);
    }
    catch (Exception oEx)
    {
        // handle exception
    }
