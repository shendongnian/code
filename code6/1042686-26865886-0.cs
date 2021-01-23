    [TestMethod]
    public void AssociationCreationFromXrmShouldDefaultWhenAssociationHoldingIsNull()
    {
        Xrm.pv_association input = new Xrmpv_association();
        input.pv_AssociationHolding = null;
        var output = PVWebApiRole.ApiModelFactory.CreateAssociationFromXrm(Input);
                
        // The fact that 'output' is valid should be tested separately
        Assert.AreEqual(output.AssociationHoldingId, Guid.Empty);
    }
    [TestMethod]
    public void AssociationCreationFromXrmShouldKeepNotNullAssociationHolding()
    {
        var sampleReference = new EntityReference("yourlogicalName", Guid.Parse("00000000-0000-0000-0000-000000000000"));
        Xrm.pv_association input = new Xrmpv_association();
        input.pv_AssociationHolding = sampleReference;
        var output = PVWebApiRole.ApiModelFactory.CreateAssociationFromXrm(Input);
        
        // The fact that 'output' is valid should be tested separately
        Assert.AreEqual(output.AssociationHoldingId, sampleReference.Id);
    }            
