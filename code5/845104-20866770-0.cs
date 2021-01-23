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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Counter += 2;
        Label1.Text = string.Format("hello{0}", this.Counter);
    }
    
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Counter += 2;
        Label1.Text = string.Format("hello{0}", this.Counter);
    }
