    public void Create(Book book) {
        SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Book (Id, Title, Language, PublicationDate, Publisher, Edition, OfficialUrl, Description, EBookFormat) VALUES (?,?,?,?,?,?,?,?)");
        insertSQL.Parameters.Add(book.Id);
        insertSQL.Parameters.Add(book.Title);
        insertSQL.Parameters.Add(book.Language);
        insertSQL.Parameters.Add(book.PublicationDate);
        insertSQL.Parameters.Add(book.Publisher);
        insertSQL.Parameters.Add(book.Edition);
        insertSQL.Parameters.Add(book.OfficialUrl);
        insertSQL.Parameters.Add(book.Description);
        insertSQL.Parameters.Add(book.EBookFormat);
        try {
            insertSQL.ExecuteNonQuery();
        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
        }    
    }
