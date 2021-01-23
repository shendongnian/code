        [TestMethod]
        public void shortage_exists()
        {
            // Setup
            var supply = new List<Warehouse>() { Globals.Instance.warehouse1, Globals.Instance.warehouse2, Globals.Instance.warehouse3 };
            Globals.Instance.warehouse1.TotalQty = 1;
            Globals.Instance.warehouse2.TotalQty = 2;
            Globals.Instance.warehouse3.TotalQty = 3;
            var demand = new List<Demand>()
            {
                new Demand(){ Job = new Job{ Id = Globals.jobId1, StockCode = Globals.stockCode100, AssembledRequiredDate = DateTime.Now}, StockCode = Globals.stockCode100, RequiredQTY = 1}, 
                new Demand(){ Job = new Job{ Id = Globals.jobId2, StockCode = Globals.stockCode200, AssembledRequiredDate = DateTime.Now}, StockCode = Globals.stockCode200, RequiredQTY = 3}, 
                new Demand(){ Job = new Job{ Id = Globals.jobId3, StockCode = Globals.stockCode300, AssembledRequiredDate = DateTime.Now}, StockCode = Globals.stockCode300, RequiredQTY = 4}, 
            };
            var alternatives = _mock.Alternatives();
            var dependencies = _mock.Dependencies(supply, demand, alternatives);
            var viewModel = new MainViewModel();
            viewModel.Register(dependencies);
            // Test
            viewModel.Load();
            AwaitCompletion(viewModel);
            // Verify
            var part100IsNotShort = dependencies.PartCache.Where(p => (p.StockCode == Globals.stockCode100) && (!p.HasShortage)).Single() != null;
            var part200IsShort = dependencies.PartCache.Where(p => (p.StockCode == Globals.stockCode200) && (p.HasShortage)).Single() != null;
            var part300IsShort = dependencies.PartCache.Where(p => (p.StockCode == Globals.stockCode300) && (p.HasShortage)).Single() != null;
            Assert.AreEqual(true, part100IsNotShort &&
                                    part200IsShort &&
                                    part300IsShort);
        }
