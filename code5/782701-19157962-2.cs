      [Fact]
      public void Validate_GivenNonNumericClaimantID_ReturnsInvalid()
      {
         int outint = 0;
         // Get a mock of a valid row
         //var mockRow = TestHelper.GetMockValidInvoiceDetailsWorksheetRow();
           var mockRow = new Mock<IXLRow>();
         // change the TryGetValue result to false
         mockRow.Setup(m => m.Cell("B").TryGetValue(out outint)).Returns(false);
         var validationResult = new InvoiceDetailsWorksheetRowValidator().Validate(mockRow.Object);
         Assert.True(validationResult.Errors.Any
           (x => x.ErrorMessage == "ClaimantID column value is not a number."));
         //Other option:
         //validationResult.Errors.Remove(validationResult.Errors.First(x => x.ErrorMessage == "InvoiceNumber column value is not a number."));
         //Assert.Equal("ClaimantID column value is not a number.", validationResult.Errors.First().ErrorMessage);
      }
     [Fact]
     public void Validate_GivenNonNumericInvoiceNumber_ReturnsInvalid()
     {
         int outint = 0; // I don't care about this value
         // Get a mock of a valid worksheet row
         var mockRow = new Mock<IXLRow>();
         mockRow.Setup(m => m.Cell("E").TryGetValue(out outint)).Returns(false);
         // Validates & asserts
         var validationResult = new InvoiceDetailsWorksheetRowValidator().Validate(mockRow.Object);
         Assert.True(validationResult.Errors.Any
              (x => x.ErrorMessage == "InvoiceNumber column value is not a number."));
         //Other option:
         //validationResult.Errors.Remove(validationResult.Errors.First(x => x.ErrorMessage == "ClaimantID column value is not a number."));
         //Assert.Equal("InvoiceNumber column value is not a number.", validationResult.Errors.First().ErrorMessage);
      }
