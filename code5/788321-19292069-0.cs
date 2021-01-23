    using (var db = new EduDataClassesDataContext())
    using (var scope = new TransactionScope())
    {
        ...
        db.UserInformations.InsertOnSubmit(userinfor);
        db.SubmitChanges();
        // The Complete method commits the transaction. If an exception has been thrown,
        // Complete is not  called and the transaction is rolled back.
        scope.Complete();
    }
