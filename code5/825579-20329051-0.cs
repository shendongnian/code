    for (int i = 0; i < myGrid.Rows.Count; i++) //Check if item is selected  
            {
              if (((CheckBox)myGrid.Rows[i].FindControl(cbname)).Checked) //If selected            
                {
                    .... //Magic Happens
                }
            }
