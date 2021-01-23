    SqlCommand sqlProjectsList = new SqlCommand("SELECT * FROM dbo.Projects ORDER BY projectName", conn);
    conn.Open();
    SqlDataReader rsProjectsList = sqlProjectsList.ExecuteReader();
    if (rsProjectsList.HasRows)//there is a project, insert into the array
    {
       while rsProjectsList.Read()
       {
          ProjectsListClass projectDetails=new ProjectsListClass();
          projectDetails.ProjectsListProjectID = Convert.ToInt16(rsProjectsList["ID"]);
          projectDetails.ProjectsListProjectName = rsProjectsList["projectName"].ToString();
          ProjectsList.Add(projectDetails);
       }
    }
    rsProjectsList.Close();
    conn.Close();
