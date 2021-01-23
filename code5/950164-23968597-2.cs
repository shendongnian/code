    protected override void OnPreInit(EventArgs e)
    {
        int Persons=0;
        if(Session["Persons"]!=null)
        Persons= int.Parse(Session["Persons"].ToString()) + 1;
        for (int i = 1; i < Persons; i++)
        {
            DropDownList DropDownList_menuchoice = new DropDownList();
            DropDownList_menuchoice.DataTextField = "titel";
            Panel1.Controls.Add(DropDownList_menuchoice);
         }
        base.OnPreInit(e);
    }
    
