     protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           TextBox txtCategoryEdit = (TextBox)GridView2.Rows(e.RowIndex).FindControl("FieldEditTextBox")  ;
                // put your update logic here 
        }
