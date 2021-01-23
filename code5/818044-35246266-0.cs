     public void PrintSql_Array()
        {
            int[] numbers = new int[4];
            string[] names = new string[4];
            string[] secondNames = new string[4];
            int[] ages = new int[4];
            int cont = 0;
            string cs = @"Server=ADMIN\SQLEXPRESS; Database=dbYourBase; User id=sa; password=youpass";
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM tbl_Datos";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        numbers[cont] = row.Field<int>(0);
                        names[cont] = row.Field<string>(1);
                        secondNames[cont] = row.Field<string>(2);
                        ages[cont] = row.Field<int>(3);
                        cont++;
                    }
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.WriteLine("{0} | {1} {2} {3}", numbers[i], names[i], secondNames[i], ages[i]);
                    }
                    con.Close();
                }
            }
        }
