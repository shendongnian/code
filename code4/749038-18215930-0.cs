    string str = "";
    foreach (string item in list)
    {
        TextBox txt = (TextBox)Form.FindControl(item);
        if (txt != null)
        {
            str += item+":"+ txt.Text+"<br>";
        }
    }
    Response.Write(str);
