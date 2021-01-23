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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack)
        {
            if (this.Counter > 0)
            {
                for (int i = 0; i < this.Counter; i++)
                {
                    Panel div = new Panel();
                    div.ID = string.Format("panel{0}", i + 1);
                    div.CssClass = "postdiv";
                    div.Style["position"] = "absolute";
                    div.Style["top"] = (60 * (i + 1)).ToString();
                    form1.Controls.Add(div);
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        this.Counter += 1;
        try
        {
            Panel div = new Panel();
            div.ID = string.Format("panel{0}", this.Counter);
            div.CssClass = "postdiv";
            div.Style["position"] = "absolute";
            div.Style["top"] = (60 * this.Counter).ToString();
            form1.Controls.Add(div);
        }
        catch (Exception er)
        {
            Console.Write(er);
        }
    }
    
