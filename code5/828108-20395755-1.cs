        List<string> UserBuiltQueries = new List<string>();
        .....
        public void DisplayCalcQuery(string argFromQueryBuilder)
        { 
            UserBuiltQueries.Add(argFromQueryBuilder);
            //displayng the user built query(queries) on the stack panel meant to display it.
            foreach (string query in UserBuiltQueries)
            {
                CheckBox checkQueries = new CheckBox() { Content = query };
                stackPanel1.Children.Add(checkQueries);
                checkboxes.Add(checkQueries);
            }
        }
