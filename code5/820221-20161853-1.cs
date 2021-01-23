       int count = 1; //count clicks    
       private void ButtonClick(object sender, EventArgs e)
            {
               if(count%2 == 0)
               {
                  label1.Visible = false;
                  label2.Visible = true;
                  label3.Visible = false;
               }
               else if(count%3 == 0){
                  label1.Visible = false;
                  label2.Visible = false;
                  label3.Visible = true;
               }
               else{
                 label1.Visible = true;
                 label2.Visible = false;
                 label3.Visible = false;
               }
            count++;
            }
