      [TestCleanup]
      public void TestCleanup()
      {
           var entity = db.Item.Find(guiItemID);
           db.Item.Remove(entity);
           db.SaveChanges();
      }
