    switch (e.CommandName.Trim())
    {
    case "Mod":
    int r1=Int32.Parse((e.CommandArgument).ToString());
    Session["id"]=GridView1.DataKeys[r1].Value.ToString();
    Response.Redirect("HumanEdit.aspx?id=" + Session["id"]);
    break;
    }
