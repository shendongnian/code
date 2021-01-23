     protected void button_Click(object sender, EventArgs e)
     {
           
           for(int i=0; i<gridView.Rows.Count; i++)
           {
               CheckBox cb = (CheckBox)gridView.Rows[i].FindControl("CheckBox1");
               if (cb.Checked == true)
               {
 
                   // use cb.Text to retrieve the checkbox text
               }
       
           }
     }
