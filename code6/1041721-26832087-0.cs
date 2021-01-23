    bool wasStatusUpdatedCorrectly = false;
    _orderRepositoryMock.Setup(x => x.Update(order))
        .Callback<Order>(o => 
        {
            wasStatusUpdatedCorrectly = o.Status == OrderStatus.Cancelled;
        });
    _orderService.Cancel(It.IsAny<Guid>());
    Assert.IsTrue(wasStatusUpdatedCorrectly);
