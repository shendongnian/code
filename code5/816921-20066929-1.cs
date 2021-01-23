        protected void btn_test1_Click(object sender, EventArgs e)
          {
              TextBox txt_test1=  grv_test.Rows[0].FindControl("txt_test1") as TextBox;
                if (txt_test1!= null)
                {
                    string value = txt_test1.Text;
                    //add your code here
                }
            }
         }
    
       protected void btn_test2_Click(object sender, EventArgs e)
          {
               TextBox txt_test1= grv_test.Rows[1].FindControl("txt_test1") as TextBox;
                if (txt_test1!= null)
                {
                    string value = txt_test1.Text;
                    //add your code here
                }
            
         }
    
       protected void btn_test3_Click(object sender, EventArgs e)
          {
               TextBox txt_test1= grv_test.Rows[2].FindControl("txt_test1") as TextBox;
                if (txt_test1!= null)
                {
                    string value = txt_test1.Text;
                    //add your code here
                }
            
         }
