      [Test]
      public void ShouldReturnProductDetails()
      {
          List<CategoryDto> categories = // ...
          categoryServiceMock.Setup(cs => cs.GetAllCategories()).Returns(categories);
          var result = controller.GetProductDetails();
          // Assert
      }
