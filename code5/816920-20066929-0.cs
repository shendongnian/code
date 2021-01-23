      protected void btn_test2_Click(object sender, EventArgs e)
      {
        foreach (GridViewRow row in grv_test.Rows)
        {
            TextBox txt_test1= row.FindControl("txt_test1") as TextBox;
            if (txt_test1!= null)
            {
                string value = txt_test1.Text;
                //add your code here
            }
        }
     }
