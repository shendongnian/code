     foreach(GridViewRow gr in GridView.Rows)
        {
           // find your all textbox
           TextBox txtA= (TextBox)gr.FindControl("txtA");
           TextBox txtB= (TextBox)gr.FindControl("txtB");
           //Check they are not null
           if(txtA!=null){
           //Assign empty string
               txtA.Text = string.empty;
               }
           if(txtB!=null){
           //Assign empty string
               txtB.Text = string.empty;
               }
        } 
