    [TestMethod]
        public void Test()
        {
          PartialViewResult response = controller.GetList(TestSearch) as PartialViewResult;
    
          Assert.AreEqual(response.ViewName,"_GetList");
    
          //Converting partial view to json string
          JavaScriptSerializer serializer = new JavaScriptSerializer(); //creating serializer instance of JavaScriptSerializer class
    
          StringBuilder builder = new StringBuilder();
          serializer.Serialize((object)response.Model, builder);
          //Checking in partial view
          Assert.IsTrue(builder.ToString().Contains("\"Success\":true"));
        }
