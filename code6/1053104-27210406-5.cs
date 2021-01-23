       protected void ImageButton_Click(object sender, EventArgs e)
       {
         
             ImageButton btn = sender as ImageButton;
             GridViewRow gRow = (GridViewRow)btn.NamingContainer;
             int id =Convert.ToInt32((gRow.FindControl("lblId") as Label).Text);
        
       }
