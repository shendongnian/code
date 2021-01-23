    <asp:GridView ID="CustomersGrIdView" 
         OnRowEditing="CustomersGridView_Editing" 
         OnRowCommand="CustomersGridView_RowCommand"
         .... />
     protected void CustomersGridView_Editing(object sender, GridViewEditEventArgs e)
        {
          e.NewEditIndex = 3; // Tested in VS 2010, Framework 4   
        }
