    [TestMethod]
    public void UpdatedBy_ShouldSet()
    {
        OperationResponse<ItemDTO> response = new OperationResponse<ItemDTO>();
        AddEditRequest request = new GasketTypeRequest();
    
        request.UpdatedBy = "userid";
    
        var Items = new List<ItemDTO>()
            {
                new ItemDTO
                {
                    ID = 1,
                    GID = 105,
                    NO = 24,
                    SHORTDESC = "test",                    
                    LONGDESC = "test",
                    STATUS = Constants.STATUS,
                    LIST = "Y",
                    Action = NameConstants.DeleteAction
                },
                    new ItemDTO
                {
                    ID = 2,
                    GID = 113,
                    NO = 246,
                    SHORTDESC = "test",                    
                    LONGDESC = "test",
                    STATUS = Constants.STATUS,
                    LIST = "Y",
                    Action = string.Empty   
                }     
            };
    
         //Assert
                 Assert.AreEqual("userid" , request.UpdatedBy,"Updated by should not be empty");
    }
