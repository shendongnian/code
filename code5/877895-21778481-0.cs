     [HttpPost]
            public ActionResult AddTest(int TestId,long Charges, string TestName)
            {
                List<Test> bookedTests = new List<Test>();
    
                if (Session["BookedTests"] != null)
                {
                    bookedTests = (List<Test>)Session["BookedTests"];
                }
    
                else
                {
    
                    Test dummyTest = new Test();
    
                    dummyTest.TestId = 0;
                    dummyTest.Charges = 0;
                    dummyTest.TestName = "dummy";
    
                    bookedTests.Add(dummyTest);
    
                }
    
                Test objTest = new Test();
    
                objTest.TestId = TestId;
                objTest.Charges = Charges;
                objTest.TestName = TestName;
    
                bookedTests.Add(objTest);
    
                Session["BookedTests"] = bookedTests;
    
                return PartialView("~/Views/TestRequest/_HiddenTestsPartial.cshtml",bookedTests);
            }
