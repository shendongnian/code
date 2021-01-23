    System.Web.UI.WebControls.TextBox txtName;
    protected void btn_ClickSubmit(object sender, Eventargs e) 
    {
     if(txtName.Text =="")
      {
       MessageBox.Show("Textbox is required");
      }
    }
