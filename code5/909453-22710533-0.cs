        [TestMethod]
        public void Get_Data_de_OdpNet_con_service_AnyCPU()
        {
            var svc = new SvcReferenceServiceOdpNet.ServiceOdpNetClient();
            DoTest(svc.GetTestOdpNetQuery, DataUtils.Select_Sysdate);
        }
    
        [TestMethod]
        public void Get_Data_de_OdpNet_con_service_x86()
        {
         var svc = new SvcReferenceServiceOdpNetx86.ServiceOdpNetClient();
         DoTest(svc.GetTestOdpNetQuery, DataUtils.Select_Sysdate);
        }
        
        // repeat this test method pattern for all 5 service references and call
        // the DoTest method.
        
        private void DoTest(Func<DateTime, string> func, DateTime sysDate)
        {
            var res = func(sysDate);
            Assert.IsNotNull(res, "Null Value");
        
            TestContext.WriteLine("Result: ");
            TestContext.WriteLine(res);
            Assert.IsFalse(res.StartsWith("ERROR"), "Error found ERROR");
        }
