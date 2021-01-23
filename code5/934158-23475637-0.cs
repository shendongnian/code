                hubMock.Setup(p => p.Groups).Returns(mockGroupManager.Object);
                hubMock.Setup(p => p.Context).Returns(mockHubCallerContext.Object);
                hubMock.Setup(p => p.Clients).Returns(mockClients.Object);
                var repository = new RepositoryHub(){ Context = mockHubCallerContext.Object,
                                                      Clients = mockClients.Object,
                                                      Groups = mockGroupManager.Object };
                var r = repository.OnConnected();
