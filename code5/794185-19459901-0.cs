    public static bool CheckoutBook(int bookID, int studentID)
    {
        try
        {
            using (var dc = new LibraryDataContext())
            {
                using(var tran = dc.Connection.BeginTransaction())
                {
                    var bookCount = dc.StudentBook.Count(a => a.StudentID == studentID);
                    if (bookCount < 5)
                    {
                        var studentBook = new StudentBook();
                        studentBook.StudentID = studentID;
                        studentBook.BookID = bookID;
                        studentBook.CreateDate = DateTime.Now;
                        dc.StudentBook.InsertOnSubmit(studentBook);
                        dc.SubmitChanges();
                        dc.Transaction.Commit();
                        return true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //the transaction failed for some reason
        }
        return false;
    }
