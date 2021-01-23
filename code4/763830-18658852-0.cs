        [TestMethod]
        public void CodedUITestMethod1()
        {
            //This takes you to the parent tab
            this.UIMap.CtrlShiftTab();
            //Assertion to confirm you're on the parent page
            this.UIMap.AssertParentPage();
            //This takes you to the new tab
            this.UIMap.CtrlTab();
            //Assertion to confirm you're on the new page
            this.UIMap.AssertNewPage();
        }
