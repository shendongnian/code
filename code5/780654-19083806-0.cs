                    var myList = new List<something>();
                    foreach (DataRow iRow in chatcheck.Rows)
                    {
                        FormCollection fc = Application.OpenForms;
                        foreach (Form f in fc)
                        {
                            if (f.Text != ChatReader["Sender"].ToString())
                            {
                               myList.Add(...)
                            }
                            else if (f.Text == ChatReader["Sender"].ToString())
                            {
                                f.BringToFront();
                            }
                        }
                    }
 
    foreach (var val in myList)
    {
       ChatBox chat = new ChatBox();
       ...
    }
