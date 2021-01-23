    System.Text.StringBuilder sb = new System.Text.StringBuilder(256*1024);
    sb.AppendText("some text");
    sb.AppendText(myObject.name);
    sb.AppendText("more text");
    Response.Write(sb.ToString());
