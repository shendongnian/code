    var scope = (new PConn.DataAccess.PressConnEntities()).Database.BeginTransaction();
    var bizl = new Mock<IOrderMgr>();
    bizl.Setup(m => m.CreateNewOrder(7, It.IsAny<string>(), It.IsAny<string>())).Returns(_testOrder1);
    // .GetOrdersQuery(channel, beginUTC, endUTC);
    bizl.Setup(m => m.GetOrdersQuery(7, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(matchedOrdersList.AsQueryable());
    bizl.Setup(m => m.BeginTransaction()).Returns(scope);
