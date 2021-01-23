        [Test()]
        public void WedgeSendsTextToVirtualKeyboardTest()
        {
            using (var form = new WedgeForm())
            using (var wedge = new KeyboardWedgeConfiguration(WEDGE_KEY))
            {
                TurnOnKeyboardWedge(wedge);
                string actual = MakeWedgeWriteHelloWorld(form, wedge); ;
                string expected = "Hello World";
                
                Expect(actual, Is.EqualTo(expected));
            }
        }
        private static string MakeWedgeWriteHelloWorld(WedgeForm form, KeyboardWedgeConfiguration wedge)
        {
            var uiThread = new Thread(() => Application.Run(form));
            uiThread.SetApartmentState(ApartmentState.STA);
            uiThread.Start();
            string actual = string.Empty;
            var thread = new Thread
                (
                    () => actual = InvokeEx<Form, string>(form, f => f.Text)
                );
            using (var sp = new System.IO.Ports.SerialPort("COM" + COMB, 115200))
            {
                sp.Open();
                sp.Write("Hello World");
            }
            //wait 1 second. This allows data to send, and pool in the wedge
            //the minimum wait time is 200ms. the string then gets put into bytes
            //and shipped off to a virtual keyboard where all the keys are pressed.
            Thread.Sleep(1000);
            InvokeEx<Form>(form, f => f.Close());
            thread.Start();
            uiThread.Join();
            thread.Join();
            return actual;
        }
