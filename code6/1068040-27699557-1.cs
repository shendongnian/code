     using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    abc temp = new abc();
    
                    while (sdr.Read())
                    {
                         temp = new abc();
                         temp.ID =  Convert.ToInt32(sdr["ID"]);
                          temp.Date =  Convert.ToDate(sdr["Date"]);
                           temp.jobtype =  Convert.ToString(sdr["job_type"]);
                         temp.command =  Convert.ToString(sdr["command"]);
                        data.Add(temp);
                    }
                    connection1.Close();
                    return data;
                }
