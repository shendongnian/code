    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))] // #1
    public void CreateAssociationFromXrmShouldCheckConditionalBranch()
    {
        Xrm.pv_association Input = new Xrm.pv_association();
        Input = null; // #2
        PVWebApiRole.ApiModelFactory.CreateAssociationFromXrm(Input);
        var expected = default(PVWebApi.Models.Association);
        Assert.IsTrue(expected == PVWebApiRole.ApiModelFactory
                                      .CreateAssociationFromXrm(Input), "Failed");
    }
