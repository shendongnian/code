        [Test]
        public void Create_UsingInterface_CreatesANewItem()
        {
            //Assign
            string parentPath = "/sitecore/content/Tests/SitecoreService/Create";
            string childPath = "/sitecore/content/Tests/SitecoreService/Create/newChild";
            string fieldValue = Guid.NewGuid().ToString();
            var db = Sitecore.Configuration.Factory.GetDatabase("master");
            var context = Context.Create(Utilities.CreateStandardResolver());
            context.Load(new SitecoreAttributeConfigurationLoader("Glass.Mapper.Sc.Integration"));
            var service = new SitecoreService(db);
            using (new SecurityDisabler())
            {
                var parentItem = db.GetItem(parentPath);
                parentItem.DeleteChildren();
            }
            var parent = service.GetItem<StubClass>(parentPath);
            var child = Substitute.For<StubInterfaceAutoMapped>();
            child.Name = "newChild";
            child.StringField = fieldValue;
            //Act
            using (new SecurityDisabler())
            {
                service.Create(parent, child);
            }
            //Assert
            var newItem = db.GetItem(childPath);
            Assert.AreEqual(fieldValue, newItem["StringField"]);
            using (new SecurityDisabler())
            {
                newItem.Delete();
            }
            Assert.AreEqual(child.Name, newItem.Name);
            Assert.AreEqual(child.Id, newItem.ID.Guid);
        }
