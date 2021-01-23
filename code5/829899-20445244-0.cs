            using (var Cn = new SqlConnection(@"Server=TheAddress;Database=MyDataBase.mdf;integrated security=True"))
            {
                Cn.Open();
                using (var Cm = new SqlCommand("", Cn))
                {
                    Cm.CommandText = "INSERT INTO Table1(ID_Food, Name_Food , TypeOfService_Food , Price_Food , Type_Food) VALUES (@ID_Food , @Name_Food , @TypeOfService_Food , @Price_Food , @Type_Food)";
                    Cm.Parameters.AddWithValue("@ID_Food", textBox1.Text);
                    Cm.Parameters.AddWithValue("@Name_Food", textBox2.Text);
                    Cm.Parameters.AddWithValue("@TypeOfService_Food", textBox3.Text);
                    Cm.Parameters.AddWithValue("@Price_Food", textBox4.Text);
                    Cm.Parameters.AddWithValue("@Type_Food", textBox5.Text);
                    Cm.ExecuteNonQuery();
                    Cn.Close();
                }
            }
