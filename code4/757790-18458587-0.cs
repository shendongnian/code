        string RequiredLine2 = "Error Msg";
        string RequiredLine1 = "Sql Stmt";
        while ((sql_line = SR.ReadLine()) != null)
        {
            if (sql_line.Contains(RequiredLine1))
            {
                //crop out string that comes before:
                int index = sql_line.IndexOf(":") + 1;
                sql_stmt_line = sql_line.Substring(index);
            }
            // error_line = SR.ReadLine();
            if (error_line.Contains(RequiredLine2))
            {
                //crop out string that comes before:
                int index = error_line.IndexOf(":") + 1;
                error_line = error_line.Substring(index);
            }
        }
