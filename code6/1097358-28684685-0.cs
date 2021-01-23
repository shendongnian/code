		[TestMethod]
        public void GetServiceRequest_User()
        {
            TestAppContext context = new TestAppContext();
            House house = new House() {address="Middle of Nowhere"};
            Perosn person = new Person() {name="Some Dude"};
			house.person = person;
            context.Houses.Add(house);
            
            HousesController controller = new HousesController(context);
            var resultRaw = controller.GetHouse(house.id);
            Assert.IsInstanceOfType(resultRaw, typeof(OkNegotiatedContentResult<House>));
            OkNegotiatedContentResult<House> result = resultRaw as OkNegotiatedContentResult<House>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content.person);
            Assert.AreEqual(result.Content.person.id, result.Content.personId);
            Assert.AreEqual(result.Content.person.id, person.id);
        }
