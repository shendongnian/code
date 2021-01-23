    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dataTbl = this.GetData();
                
        //Cast the Rows collection so we can use LINQ
        IEnumerable<dynamic> data = dt.Rows.Cast<DataRow>()
            
            // Group the DataRows by the column ["Author"]
            .GroupBy<DataRow, String>(d => Convert.ToString(d["Author"]))
            
            // GroupBy returns an IEnumerable<IGrouping<TKey, TSource>>
            // in this case we have a String (Authors Name) and 
            // DataRows with the book information. From these IGroupings
            // we want to return a dynamic class that has properties:
            //  - Author (string it is the .Key in the IGrouping) 
            //  - Books (Collection of another dynamic class that has Book properties)
            .Select<IGrouping<String, DataRow>, dynamic>(grp => {
                return new {
                    Author = grp.Key,
                    // grp right now is a collection of DataRows
                    // make each row into a dynamic class that has
                    // book properties so that Eval("PropName")
                    // plays nice
                    Books = grp.Select<DataRow, dynamic>(row => {
                        return new {
                            Book = Convert.ToString(row["Book"]),
                            PublishDate = Convert.ToString(row["PublishDate"]),
                            Pages = Convert.ToString(row["Pages"])
                        };
                    })
                };
            });
    
        RepeaterOuter.DataSource = data;
        RepeaterOuter.DataBind();
    }
