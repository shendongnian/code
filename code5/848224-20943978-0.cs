    protected void Page_Init(Object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            if (drpYourDropDown.Items.Count > 0 && drpYourDropDown.SelectedItem.Text == "yourOption")
            { 
                AddIDLControl();
            }
        }
    }
    private void AddIDLControl()
    {
        controls.IDLControl IdlControl = LoadControl(@"~/controls/IDLControl.ascx") as controls.IDLControl;
        IdlControl.ClientIDMode = ClientIDMode.Static;
        IdlControl.ID = "IDLControl";
        spGroup.Controls.Clear();
        spGroup.Controls.Add(IdlControl);
    }
