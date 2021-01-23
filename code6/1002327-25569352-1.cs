    public string DisplayWarning()
    {
        using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RechnungConnectionString"].ConnectionString))
        using (var datecmd = new SqlCommand("Select DATEDIFF(day,Date,Getdate()) as DiffDate From Invoice", conn))
        {
            conn.Open();
            using (var reader = datecmd.ExecuteReader())
            {
                if (reader.HasRows){
                    while (reader.Read())
                    {
                        int regTime = reader.GetInt32(0);
                        string statusColor;
                        if (regTime < 7)
                        {
                            statusColor = "Image/green-4040.jpg";
                        }
                        else if (regTime >= 7 && regTime < 14)
                        {
                            statusColor = "Image/yellow-4040.jpg";
                        }
                        else if (regTime >= 14 && regTime < 21)
                        {
                            StatusColor = "Image/orange-4040.jpg";
                        }
                        else
                        {
                            statusColor = "Image/red-4040.jpg";
                        }
                        returnstatusColor;
                    }
                }
                else{ 
                    // output, log, exception ?!
                }
            }
        }
    }
