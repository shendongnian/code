    private int Counter
    {
       get
       {
          if (ViewState["Counter"] == null)
          {
             return 0;
          }
          else
          {
             return (int)ViewState["Counter"];
          }
       }
       set
       {
          ViewState["Counter"] = value;
       }
    }
    private bool DropDown1Selected
    {
       get
       {
          if (ViewState["DropDown1Selected"] == null)
          {
             return false;
          }
          else
          {
             return (bool)ViewState["DropDown1Selected"];
          }
       }
       set
       {
          ViewState["DropDown1Selected"] = value;
       }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!this.DropDown1Selected)
        {
            this.DropDown1Selected = true;
            this.Counter += 2;
        }
        Label1.Text = string.Format("hello{0}", this.Counter);
    }
    
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Counter += 2;
        Label1.Text = string.Format("hello{0}", this.Counter);
    }
