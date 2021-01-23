        [TestMethod]
        public async Task Login_Test()
        {
            // Arrange
            var logonModel = new LoginViewModel() { UserName = "Admin", Password = "admin123" };
            // Validate model state start
            var validationContext = new ValidationContext(logonModel, null, null);
            //set validateAllProperties to true to validate all properties; if false, only required attributes are validated.
            Validator.TryValidateObject(logonModel, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                controller.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
            // Validate model state end
            // Act
            var result = await controller.Login(logonModel, null) as RedirectToRouteResult;
            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
