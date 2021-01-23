    public void Default_Index_Returns_Data()
        {
            //Arrange
            var appmockContext = new Mock<IApplicationContext>();
            var mgmtmockContext = new Mock<IManagementService>();
            var domainmockContext = new Mock<IDomainService>();
            var agency1 = new Agency() { Name = "Test Agency" };
            List<Client> db = new List<Client>();
            
            db.Add(new Client { ClientId = 1, Name = "Test Client 1", AgencyId = 1 });
            db.Add(new Client { ClientId = 2, Name = "Test Client 2", AgencyId = 1 });
            //Act
            mgmtmockContext
                .Setup(m => m.GetAllClients(It.IsAny<bool>()))
                .Returns(() => { return db.AsMockDbSet().Object; });
            ClientController controller = new ClientController(appmockContext.Object, mgmtmockContext.Object, domainmockContext.Object);
            var resultTask = controller.Index();
            resultTask.Wait();
            var result = resultTask.Result;
            var model = (List<Client>)((ViewResult)result).Model;
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, model.Count());
        }
