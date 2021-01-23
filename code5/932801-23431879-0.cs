        [TestMethod]
        public void GetTicketId()
        {
            var mockMyService = new Mock<IMyService>();
            mockMyService.Setup(n => n.GetTicketId(It.IsAny<Coordinate[]>))
                         .Returns("Not Null String");
            var objectUnderTest = new ObjectUnderTest(mockMyService);
            
            var ticketId = objectUnderTest.GetTicketId();
            Assert.IsNotNull(ticketId);
        }
