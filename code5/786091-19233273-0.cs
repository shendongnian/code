        SqlCommand cmd = new SqlCommand("INSERT INTO PC_QA_REPORT_1  (Project_ID, Project_Title, Date, Project_Quality_Rating, Project_Decision, Project_Strategic, Project_Relevant, Project_Monitoring_Eval, Project_Efficient, Project_Effective, Project_Sus_Nat_Own, Project_QA_Summary, Project_Document_Status) VALUES('" + pid + "','" + ptitle + "','" + date + "','" + pqr + "','" + pd + "','" + ps + "','" + pr + "','" + pme + "','" + pef + "','" + pet + "','" + psno + "','" + pqs + "','" + pds + "')", con);
        SqlCommand command = new SqlCommand("INSERT INTO PC_QA_REPORT_2 (Project_M_Date, Project_M_Responsibility,Project_M_Notes) VALUES('" + pmd + "','" + pmr + "','" + pmn + "')", con);
    command += "; " + cmd;
    int x = command.ExecuteNonQuery();
    con.Close()
    return x;
