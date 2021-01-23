     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
            {
                DropDownList ddl = (DropDownList)sender;
                GridViewRow row = (GridViewRow)ddl.Parent.Parent;
                int idx = row.RowIndex;
                if (ddl.SelectedValue == "Task A")
                {
                    DoTaskA();
                }
                else if (ddl.SelectedValue == "Task B")
                {
    
                    DoTaskB();
                }
    
    
            }
            public void DoTaskA()
            {
                // do things here
            }
    
            //Call if task B selected in DDL
            public void DoTaskB()
            {
                // do things here
            }
