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
    
    private int StyleTop
    {
       get
       {
          if (ViewState["StyleTop"] == null)
          {
             return 0;
          }
          else
          {
             return (int)ViewState["StyleTop"];
          }
       }
       set
       {
          ViewState["StyleTop"] = value;
       }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Counter += 1;
        this.StyleTop += 60;
    
        try
        {
            Panel div = new Panel();
            div.ID = string.Format("panel{0}", this.Counter);
            div.CssClass = "postdiv";
            div.Style["position"] = "absolute";
            div.Style["top"] = this.StyleTop.ToString();
            form1.Controls.Add(div);
        }
        catch (Exception er)
        {
            Console.Write(er);
        }
    }
