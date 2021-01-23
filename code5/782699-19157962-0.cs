       [Fact]
        public void Validate_GivenNonNumericInvoiceNumber_ReturnsInvalid()
        {
            int outint = 0; // I don't care about this value
            // Get a mock of a valid worksheet row
            var mockRow = new Mock<IXLRow>();
            mockRow.Setup(m => m.Cell("E").TryGetValue(out outint)).Returns(false);
            // Validates & asserts
            var validationResult = new InvoiceDetailsWorksheetRowValidator().Validate(mockRow.Object);
            validationResult.Errors.Remove(validationResult.Errors.First(x => x.ErrorMessage == "ClaimantID column value is not a number."));
            
            Assert.False(validationResult.IsValid);
            // Placed here to ensure it's the only error message. This is where it fails.
            Assert.Equal("InvoiceNumber column value is not a number.", validationResult.Errors.First().ErrorMessage);
        }
