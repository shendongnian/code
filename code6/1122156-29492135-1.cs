        private void Button1_Click(object sender, EventArgs MyEventArgs)
        {
              string controlName = TextBox
    
              for(int i=1;i<4;i++)
              {
               // Find control on page.
               Control myControl1 = FindControl(controlName+i);
               if(myControl1!=null)
               {
                  // Get control's parent.
                  Control myControl2 = myControl1.Parent;
                  Response.Write("Parent of the text box is : " +  myControl2.ID);
              }
              else
              {
                 Response.Write("Control not found");
              }
             }
              
        }
