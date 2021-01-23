    HttpCookie myCookie = new HttpCookie("MyTestCookie");
    // Set the cookie value.
    myCookie.Value = MyColorLabel.Text;
    // Set the cookie expiration date.
    myCookie.Expires = DateTime.Now.AddMinutes(1);
    // Add the cookie.
    Response.Cookies.Add(myCookie);
