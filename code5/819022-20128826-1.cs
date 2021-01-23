    if(clst1.CheckedItems.Cast<object>()
                         .Any(x=>object.Equals(x.ToString(),"value1"))&&
       !clst2.CheckedItems.Cast<object>()
                         .Any(x=>object.Equals(x.ToString(),"value2"))){ 
       MessageBox.Show("if value 1 is selected value 2 must be selected", 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
