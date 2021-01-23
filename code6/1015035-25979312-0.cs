    var results2 = objectSet.ToList().Where(doc=>System.Data.Objects.SqlClient.SqlFunctions.DataLength( doc.BINARYCONTENT)>50000);
    Assert.IsTrue(results2.ToList().Count == 9);
    
    var results3 = db.DOCUMENTS.ToList().Where(doc => System.Data.Objects.SqlClient.SqlFunctions.DataLength(doc.BINARYCONTENT) > 50000);
    Assert.IsTrue(results3.ToList().Count == 9);
