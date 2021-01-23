    using SqlConnection conn = new SqlConnection(yourConnectionString)
    {
        StringBuilder query = new StringBuilder();
        query.AppendLine("SELECT SUM(CASE WHEN State = 'S' THEN 1 ELSE 0 END) AS Sold");
        query.AppendLine(", SUM(CASE WHEN State = 'B' THEN 1 ELSE 0 END) AS Booked");
        query.AppendLine(", SUM(CASE WHEN State = 'A' THEN 1 ELSE 0 END) AS Available");
        query.AppendLine("FROM ");
        query.AppendLine("(SELECT S1, S2, S3, S4, S5, S6, S7, S8");
        query.AppendLine("(,S9, S10, S11, S12, S13, S14, S15, S16");
        query.AppendLine("(,S17, S18, S19, S20, S21, S22, S23, S24");
        query.AppendLine("(,S25, S26, S27, S28, S29, S30, S31, S32");
        query.AppendLine("FROM Seats) s");
        query.AppendLine("UNPIVOT");
        query.AppendLine("(State FOR Seat IN (S1, S2, S3, S4, S5, S6, S7, S8");
        query.AppendLine("(,S9, S10, S11, S12, S13, S14, S15, S16");
        query.AppendLine("(,S17, S18, S19, S20, S21, S22, S23, S24");
        query.AppendLine("(,S25, S26, S27, S28, S29, S30, S31, S32)) AS rows;");
        conn.Open();
        using SqlCommand command = new SqlCommand(query.ToString(), conn)
        {
            DataTable data = new DataTable();
            data.Load(command.ExecuteReader());
            //then get your values
            Int32 avialable = 0;
            Int32 booked= 0;
            Int32 sold = 0;
            if(data.Rows.Count > 0)
            {
                available = (Int32)data(0)("Available");
                booked = (Int32)data(0)("Booked");
                sold = (Int32)data(0)("Sold");
            }           
        }
    }
