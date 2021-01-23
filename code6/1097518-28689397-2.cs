    class cAccess
    {
        private static string usn1;
        public string usnt
        {
          set
          {
            usn1 = value;
          }
          get
          {
            StringBuilder s = new StringBuilder();
            DataSet dsa = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand("select * from access where id=" + usn1, connection.setCon());
            adp.Fill(dsa, "t");
            DataRow DBrow = dsa.Tables["t"].Rows[0];
           for (int i = 0; i < 3; i++)
           {
             s.Append(DBrow.ItemArray.GetValue(i).ToString());
           }
      
           usn1 = s.ToString();
           return(usn1);
     }
