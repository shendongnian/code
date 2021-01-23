        [TestMethod]
    public void InsertBookIntoDb() {
        Database db = new Database();
        db.insertBooks("A", "C", "T");
    
        OleDbCommand countCommand = new OleDbCommand("SELECT COUNT(*) FROM Book", db.DbConnection);
        int count = countCommand.ExecuteScalar();
    
        Assert.AreEqual(1, count);
    }
