     void DoFooFooData_DoesSomeFooAndReturns3()
        {
          var mock = new Mock<IFooAdapter>();
          var table = new Data.Foo.FooDataTable();
          table.Add(new Data.Foo.FowRow{bar=1});
          table.Add(new Data.Foo.FowRow{bar=2});
          mock.Setup(m=>m.GetByID(It.IsAny<int>()).Returns(table);
        
          var sut = new MyFooClass();
          var expected=3;
          var actual=sut.DoFooFooData(mock.Object);
          Assert.AreEqual(expected,actual);
        }
