    [TestMethod]
        public void GetAgencyCase_Returns_AgencyCaseDetailsResponse()
        {
            var appHost = new BasicAppHost().Init();//this is needed for caching
            Container container = appHost.Container;
            Mock<IChangeRequestService> changeRequestService = new Mock<IChangeRequestService>();
            Mock<IRequestService> requestService = new Mock<IRequestService>();
            //Build the case we want returned
            Case testCase = Builder<Case>.CreateNew()
                .With(x => x.CaseId = "123")
                .And(x => x.CaseNumber = "456")
                .With(x => x.Agencies = Builder<CasesAgency>.CreateListOfSize(1)
                    .All()
                    .With(m => m.Agency = Builder<Agency>.CreateNew().With(z => z.AgencyId = 2).And(z => z.AgencyName = "Test").Build())
                    .Build())
                .With(x => x.Requests = Builder<Request>.CreateListOfSize(5)
                    .Build())
                    .Build();
            requestService.Setup<Case>(x => x.GetCase(It.IsAny<CaseSearchCriteria>(), It.IsAny<AuthenticatedUser>()))
                .Returns(testCase);
            container.Register<IChangeRequestService>(changeRequestService.Object);
            container.Register<IRequestService>(requestService.Object);
            container.Register<ILog>(new Mock<ILog>().Object);
            container.Register<ICacheClient>(new MemoryCacheClient());
            container.RegisterAutoWired<AgencyCaseService>();
            var service = container.Resolve<AgencyCaseService>();
            service.SetResolver(new BasicResolver(container));
            var context = new MockRequestContext() { ResponseContentType = ContentType.Json };
            service.RequestContext = context;
           
            
            var response = service.Get(new GetAgencyCase { AgencyId = 2, AgencyCaseNumber = "123" });
            ...assert stuff
        }
