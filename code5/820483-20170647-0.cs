    public void CRUDStudentTable()
    {
            using (OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Documents and Settings\Microsoft User\Desktop\Student.accdb"))
            {
                try
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(Query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception exception)
                {
                    message = exception.Message;
                    // Consider re-throwing the exception here
                    // to let callers know what happened.
                    // Silently harvesting the message and continuing
                    // is not a good practice of handling exceptions.
                }
            }
    }
