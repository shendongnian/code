    protected void btn_test2_Click(object sender, EventArgs e)
            {
                TextBox txt = (TextBox)grv_test.Rows[0].FindControl("txt_test1");
                 string test = txt.Text;
    
                lbl_result.Text = "You have changed the textbox to " + test;
            }
