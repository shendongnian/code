        public void test(){
            //DataBrokerSql is my own helper.
            using (DataBrokerSql db = new DataBrokerSql(m_ConnString))
            {
                bool columnsChecked = false; 
                bool hasFirstName = false; 
                bool hasLastName = false;
                using (DbDataReader reader = db.GetDataReader("Select * From Person"))
                {
                    if(!columnsChecked){
                        hasFirstName = reader.HasColumn("FirstName");
                        hasLastName = reader.HasColumn("LastName"); 
                        columnsChecked = true;
                    }
                    if (hasFirstName)
                    {
                        //Read FirstName
                        var firstName = reader["FirstName"];
                    }
                    if (hasLastName)
                    {
                        //Read LastName
                        var lastName = reader["LastName"];
                    }
                }
            }
        } 
