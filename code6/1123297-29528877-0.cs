    protected override void OnInit(EventArgs e){
    base.OnInit(e);
    controlidlist = ViewState["controlidlist"] as List<string>;
    if(controlidlist !=null)
    {
    foreach (string Id in controlidlist)
    {
        i++;
        TextBox tb = new TextBox();
        tb.ID = Id;
        LiteralControl lineBreak = new LiteralControl();
        DropDownList dl = new DropDownList();
        dl.ID = "dropdownlist" + i;
        dl.DataTextField = "cloth";
        dl.DataValueField = "cloth";
        dl.DataSource = obj.getclothitems();
        dl.DataBind();
        DropDownList dldl = new DropDownList();
        dldl.ID = "dropdownlistdropdownlist" + i;
        dldl.Items.Insert(0, "MALE");
        dldl.Items.Insert(0, "FEMALE");
        dldl.Items.Insert(0, "HOME");
        dldl.SelectedIndexChanged += dropdownlistchanged1;
        dldl.AutoPostBack = true;
        //PlaceHolder1.Controls.Add(tb);
        //PlaceHolder1.Controls.Add(lineBreak);
        textboxespanel.Controls.Add(tb);
        textboxespanel.Controls.Add(lineBreak);
        textboxespanel.Controls.Add(dldl);
        textboxespanel.Controls.Add(lineBreak);
        textboxespanel.Controls.Add(dl);
        textboxespanel.Controls.Add(lineBreak);
    }
    }
    }
