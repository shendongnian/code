            //Considering you have all the tables that share the same schema
            //i.e. All are having same column names and types
            //Create an In Memory DataTable
            DataTable consolidateTable = new DataTable("ConsolidatedTable");
            //Add columns with that is same across all of you tables
            consolidateTable.Columns.Add(new DataColumn("firstColumn"));
            consolidateTable.Columns.Add(new DataColumn("secondColumn"));
            //etc..
            //Now go through each record of each table
            foreach (DataTable dt in oDs.Tables)
            {
                foreach (DataRow row in dt.Rows)
                {
                    consolidateTable.Rows.Add(row);
                }
            }
            //bind
            gvFeeds.DataSource = consolidateTable;
            gvFeeds.DataBind();
