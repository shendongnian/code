    // Outside of Web Forms page class, use HttpContext.Current.
    HttpContext context = HttpContext.Current;
    context.Session["editID"] = index;
    ...
    int Id = (string)(context.Session["editID"]);
