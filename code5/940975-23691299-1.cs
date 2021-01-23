            private class Foo
            {
                public string Bar { get; set; } 
            }
    
            [TestMethod]
            public void SetPropertyValuesForMiscTests()
            {
                var foos = new[] { new Foo { Bar = "hi" }, new Foo { Bar = "hello" } };
                var newList = foos.SetPropertyValues(f => f.Bar = "bye");
    
                Assert.AreEqual("bye", newList.ElementAt(0).Bar);
                Assert.AreEqual("bye", newList.ElementAt(1).Bar);
            }
