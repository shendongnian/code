    using System;
    using System.Text.RegularExpressions;
    
    class Program {
        static void Main() {
            string error = "System.Data.SqlClient.SqlException: The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_state_name\". The conflict occurred in database \"StateDB\", table \"dbo.State\", column 'State_Name'";
            Regex rt = new Regex("table \"([^\"]*)\"");
            Match m = rt.Match(error);
            string table = m.Groups[1].Value;
            Regex rc = new Regex("column '([^']*)'");
            m = rc.Match(error);
            string column = m.Groups[1].Value;
            Console.WriteLine("table {0} column {1}",table,column);
        }
    }
