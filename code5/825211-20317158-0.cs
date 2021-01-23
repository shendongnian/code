    [Test]
    public void CascadesOnUpdate()
    {
        using (var dbConn = ConnectionString.OpenDbConnection())
        {
            dbConn.CreateTable<TypeWithOnDeleteAndUpdateCascade>(true);
            dbConn.Save(new ReferencedType { Id = 1 });
            dbConn.Save(new TypeWithOnDeleteAndUpdateCascade { Id = 1, RefId = 1 });
            Assert.AreEqual(1, dbConn.Select<ReferencedType>().Count);
            Assert.AreEqual(1, dbConn.Select<TypeWithOnDeleteAndUpdateCascade>().Count);
            dbConn.Update<ReferencedType>(new { Id = "2" }, p => p.Id== "1");
            TypeWithOnDeleteAndUpdateCascade obj = db.Single<TypeWithOnDeleteAndUpdateCascade>("Id = 1")
            Assert.AreEqual(obj.RefId, 2);
            // making sure that the RefId got updated, because of the cascade.
        }
    }
