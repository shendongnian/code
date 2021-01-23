            if (!Page.IsPostBack)
            {
               
                try
                {
                    string test = (string)Session["test"];
                    int value = int.Parse(test);
                    DropDownList2.SelectedIndex = value;
                }
                catch
                {
                }
            }
      
     protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
                {
                    Session["test"] = ""+ DropDownList2.SelectedIndex;
             
                }
