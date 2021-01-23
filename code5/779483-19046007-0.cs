    public int ValueToStore 
    {
       get
       { 
           return Session["ValueToStore"] != null
               ? (int)Session["ValueToStore"]
               : 0
       }
       set
       {
           Session["ValueToStore"] = value;
       }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    { 
        ValueToStore = Convert.ToInt32(TextBox1.Text);
        Response.Redirect("ulogin.aspx");
    }
