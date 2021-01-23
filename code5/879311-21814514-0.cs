    public class Book
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
        public static List<Book> GetMyBooks()
        {
            var bookList = new List<Book>();
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required))
            {
                const string connString = "Data Source=.;Initial Catalog=BookStore;Integrated Security=True";
                using (var conn = new SqlConnection(connString))
                {
                    using (var com = new SqlCommand())
                    {
                        com.CommandType = CommandType.StoredProcedure;
                        com.CommandText = "GetAllBook";
                        com.Connection = conn;
                        using (var bookdataAdapter = new SqlDataAdapter(com))
                        {
                            using (var bookDataSet = new DataSet())
                            {
                                bookdataAdapter.Fill(bookDataSet, "Book_TBL");
                                foreach (DataRow dr in bookDataSet.Tables["Book_TBL"].Rows)
                                {
                                    bookList.Add(new Book
                                    {
                                        Name = dr["book_name"].ToString(),
                                        Description = dr["book_desc"].ToString()
                                    });
                                }
                                using (var updateCommand = new SqlCommand())
                                {
                                    updateCommand.CommandText = "updateBook";
                                    updateCommand.CommandType = CommandType.StoredProcedure;
                                    updateCommand.Connection = conn;
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }
                transactionScope.Complete();
                
                return bookList;
            }
        }
