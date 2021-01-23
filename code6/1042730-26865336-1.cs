    [TestMethod]
    public void CreateAssociationFromXrmShouldCheckConditionalBranch()
    {
        Xrm.pv_association Input = new Xrm.pv_association();
        var output = PVWebApiRole.ApiModelFactory.CreateAssociationFromXrm(Input);
        Assert.AreEqual(Guid.Empty, output.CreatedByUserProfileId);
    }
