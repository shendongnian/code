    [WebMethod]
       // [ScriptMethod(UseHttpGet = true)]
        public static string test(string noSeat)
        {
            SqlConnection conn = DBConnection.getConnection();
            SqlCommand cmd;
            SqlDataReader dr;
            conn.Open();
            string sql = "Select noBooking,noSeat FROM booking WHERE noSeat = '" + noSeat +"' AND statusBooked = 1";
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            List<booking> BookList = new List<booking>();
            while (dr.Read())
            {
                booking bookClass = new booking();
                bookClass.noBooking =(int)dr[0];
                bookClass.noSeat = dr[1].ToString();
                BookList.Add(bookClass);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(BookList).ToString();
        }
