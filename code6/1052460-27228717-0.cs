        [TestMethod]
        public void TestMethod1()
        {
            bool finished = false;
            TestForm form = new TestForm();
            form.Finish += () =>
            {
                finished = true;
            };
            form.SetText();
            while (!finished)
            {
                Application.DoEvents();
                Thread.Yield();
            }                         
            Assert.IsTrue(!string.IsNullOrEmpty(form.txtResult.Text));
        }
