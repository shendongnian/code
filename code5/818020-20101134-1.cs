    foreach (string name in Request.Form.AllKeys)
    {
        if (name.IndexOf("amount", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            Response.Write(Request.Form[name]);
        }
        else
        {
            Response.Write("Not working\n");
        }
    }
