    private void ListView1_SelectedIndexChanged_UsingItems(
    		object sender, System.EventArgs e)
    {
      if (listView1.SelectedItems.Count == 1)
      {
       string Myval =ListView1.SelectedValue;    //Assumeing this is your ID
       string MyText=ListView1.SelectedItems[0].Text
      Response.Redirect("http:/newpage.aspx?ID="+Myval );
     }
    }
    
