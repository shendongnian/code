     [TestMethod]
     public void PreAuthorize_WithEmptyRequest_ReturnsNonNullResponse()
     {
         // Arrange
         var request = new Mock<IPaymentRequest>();
        
         // Act
         var authorizeResponse = _dataProcessor.SendRequest(request);
        
         // Assert
         Assert.IsNotNull(authorizeResponse);
     }
