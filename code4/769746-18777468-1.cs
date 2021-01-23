        public static void insert()
        {
            try
            {
                string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\test.accdb;Persist Security Info=False";
                string commandText = "INSERT INTO patientinfo (medicareNo, title, fName, lName, gender, height, weight, age )" +
                                    " VALUES(?, ?, ?, ?, ?, ?, ?, ?)";
                using (OleDbConnection con = new OleDbConnection(connStr))
                using (OleDbCommand cmd = new OleDbCommand(commandText, con))
                {
                    cmd.Parameters.AddWithValue("@medicareNo", p.getMedicare());
                    cmd.Parameters.AddWithValue("@title", p.getTitle());
                    cmd.Parameters.AddWithValue("@fName", p.getfName());
                    cmd.Parameters.AddWithValue("@lName", p.getlName());
                    cmd.Parameters.AddWithValue("@gender", p.getGender());
                    cmd.Parameters.AddWithValue("@height", p.getheight());
                    cmd.Parameters.AddWithValue("@weight", p.getweight());
                    cmd.Parameters.AddWithValue("@age", p.getAge());
                    con.Open();
                    int ret = cmd.ExecuteNonQuery();
                    if(ret ==1)
                        Console.WriteLine("Insert Successful");
                }
                displayResult(p.getMedicare());
            }
            catch (OleDbException exp)
            {
                Console.WriteLine("Error");
            }
        }
        public static void displayResult(int medicareNo)
        {
            try
            {
                string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=G:\test.accdb;Persist Security Info=False";
                string commandText = "SELECT * FROM patientinfo WHERE medicareNo = ?";
                using (OleDbConnection con = new OleDbConnection(connStr))
                using (OleDbCommand cmd = new OleDbCommand(commandText, con))
                {
                    cmd.Parameters.AddWithValue("@medicareNo", medicareNo);
                    con.Open();
                    using (OleDbDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.HasRows)
                        {
                            foreach (DataRow row in rdr.GetSchemaTable().Rows)
                            {
                                Console.Write(row["ColumnName"].ToString() + " ");
                            }
                            Console.WriteLine(" ");
                            while (rdr.Read())
                            {
                                string str = string.Format("{0} {1} {2} {3} {4} {5} {6} {7}", 
                                    rdr["medicareNo"], rdr["title"], rdr["fName"], rdr["lName"],
                                    rdr["gender"], rdr["height"], rdr["weight"], rdr["age"]);
                                Console.WriteLine(str);
                            }
                            Console.WriteLine("Patient registered. Information retrieved. ");
                        }
                        else
                        {
                            Console.WriteLine("Patient not registered. Add Patient information for registration.");
                        }
                    }
                }
            }
            catch (OleDbException exp)
            {
                Console.WriteLine("error.");
            }
        }
