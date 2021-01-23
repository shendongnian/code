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
    private int DropDown1Counter
    {
       get
       {
          if (ViewState["DropDown1Counter"] == null)
          {
             return 0;
          }
          else
          {
             return (int)ViewState["DropDown1Counter"];
          }
       }
       set
       {
          ViewState["DropDown1Counter"] = value;
       }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.DropDown1Counter <= 1)
        {
            this.Counter += 2;
        }
        Label1.Text = string.Format("hello{0}", this.Counter);
        this.DropDown1Counter += 1;
    }
    
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Counter += 2;
        Label1.Text = string.Format("hello{0}", this.Counter);
    }
