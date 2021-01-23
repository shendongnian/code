        Database.SetInitializer(new DropCreateDatabaseAlways<TestContext>());
                    var context = new TestContext();
                    context.TestClasses
                        .Add(new TestClass() { ClassId = 10, ClassDescription = "First row", ClassName = "Name" });
    context.SaveChanges();
