     [TestMethod]
     public void Index_Get_ReturnIndexView()
     {
         var ppsessionVariable = new Mock<IPPortalSessionVariables>();
         var controller = CreateController();
         controller.SetPortalSession(ppsessionVariable.object);
         var child = new ChildModel();
         child.Id = 0;
         ppsessionVariable.Setup(x => x.CurrentChild).Returns(child);
         var result = controller.Index() as ViewResult;
         Assert.IsNotNull(result);
      }
