    private void BtnSubmit_GotFocus(object sender, HtmlElementEventArgs e)
    {
        var btnSubmit = sender as HtmlElement;
        btnSubmit.RaiseEvent("onclick");
        btnSubmit.InvokeMember("click");
    }
