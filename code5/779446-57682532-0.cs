    HtmlElement xUsername = xDoc.GetElementById("username_txt");
    HtmlElement xPassword = xDoc.GetElementById("password_txt");
    HtmlElement btnSubmit = xDoc.GetElementById("btnSubmit");
    if (xUsername != null && xPassword != null && btnSubmit != null)
    {
        xUsername.SetAttribute("value", "testUserName");
        xPassword.SetAttribute("value", "123456789");
        btnSubmit.GotFocus += BtnSubmit_GotFocus;
        btnSubmit.Focus();
    }
