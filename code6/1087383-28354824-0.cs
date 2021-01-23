     while (dr.Read())
            {
                Id = dr["Id"].ToString();
                School = dr["School"].ToString();
                TeamName = dr["TeamName"].ToString();
                submissionDate = dr["submissionDate"].ToString();
                status = dr["submissionStatus"].ToString();
    
                subStatus.Add(new Submission(Id, School, TeamName, submissionDate, status));
            }
