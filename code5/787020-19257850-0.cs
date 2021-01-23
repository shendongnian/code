    using System;
    using System.Data;
    using System.Data.SqlClient;
    namespace MockLibrary
    {
    internal class Book
    {
        #region Constructors
        public Book()
        {
        }
        public Book(string resId, string memberId, string bookId, DateTime issueDate,     DateTime actRetDate)
        {
            this.ResId = resId;
            this.MemberId = memberId;
            this.BookId = bookId;
            this.IssueDate = issueDate;
            this.ActRetDate = actRetDate;
        }
        #endregion
        #region Properties
        private string _ResID;
        private string _MemberID;
        private string _BookId;
        private DateTime _IssueDate;
        private DateTime _ActRetDate;
        public string ResId
        {
            get { return _ResID; }
            set { _ResID = value; }
        }
        public string MemberId
        {
            get { return _MemberID; }
            set { _MemberID = value; }
        }
        public string BookId
        {
            get { return _BookId; }
            set { _BookId = value; }
        }
        public DateTime IssueDate
        {
            get { return _IssueDate; }
            set { _IssueDate = value; }
        }
        public DateTime ActRetDate
        {
            get { return _ActRetDate; }
            set { _ActRetDate = value; }
        }
        #endregion
        public Book GetBookByID(string resId, string memberId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("put your db con string here"))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetBookById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ResId", SqlDbType.VarChar).Value = resId;
                        cmd.Parameters.Add("@MemberId", SqlDbType.VarChar).Value = memberId;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        SqlDataReader  rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Book newBook = new Book(rdr["ResId"].ToString(),rdr["MemberId"].ToString(),rdr["BookId"].ToString(),DateTime.Now,DateTime.Now);
                            return newBook;
                        }
                    }
                }
            }
            catch
            {
                throw new Exception("something went wrong");
            }
            return null;
        }
        public bool CheckoutBook(string resId, string memberId)
        {
            using (SqlConnection con = new SqlConnection("put your db con string here"))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CheckoutBook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ResId", SqlDbType.VarChar).Value = resId;
                    cmd.Parameters.Add("@MemberId", SqlDbType.VarChar).Value = memberId;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if (rdr["checkoutsuccessful"].ToString() == "1")
                        {
                            return true;
                        }
                    }
                    
                }
            }
            return false;
        }
    }
}
