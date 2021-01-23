    //viewselected is list of strings
    //combobox1 has all items from the viewselected as options
    
    //start building the select query
            string command = "SELECT ";
            for (int i = 0; i < viewselected.Count; i++)
            {//add each selected database item
                if (i == viewselected.Count - 1)
                {//if it's the last item in the list don't add a comma
                    command = command + viewselected[i];
                    Console.WriteLine("Showing " + AcessStuff.viewselected[i]);
                }
                else
                {
                    command = command + viewselected[i] + ",";
                    Console.WriteLine("Showing " + AcessStuff.viewselected[i]);
                }
            }//add last pice of query command - the combobox has all the columns that are
             // in the list added so the user can select a column to sort it on
            command = command + " FROM ART ORDER BY " + comboBox1.Text.ToString() + "";
