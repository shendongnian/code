            string connStr = "server=****;database=" + projName + ";user=***;port=****;password=****;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            try
            {
                conn.Open();
                cmd = new MySqlCommand("INSERT INTO " + projName +
                    ".project(ProjectID,ProjectName,ProjectStartDate,ProjectEndDate,ProjectNotes) VALUES"
                    + "(?projectid, ?projectnamecolumn,?projectstartdatecolumn,?projectenddatecolumn,?projectnotescolumn);", conn);
                cmd.Parameters.AddWithValue("?projectid", proj.ProjectID);
                cmd.Parameters.AddWithValue("?projectnamecolumn", proj.ProjectName);
                cmd.Parameters.AddWithValue("?projectstartdatecolumn", proj.ProjectStartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("?projectenddatecolumn", proj.ProjectEndDate.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("?projectnotescolumn", proj.ProjectNotes);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
