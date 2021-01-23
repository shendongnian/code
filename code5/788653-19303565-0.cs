        protected void Page_Load(object sender, EventArgs e)
        {
            if (controlLoaded.Value == "1")
            {
                AddControl();
            }
        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            AddControl();
        }
        protected void myButton_ServerClick(object sender, EventArgs e)
        {
            result.Text = "OK";
        }
        public object getControl()
        {
            var ph = new PlaceHolder();
            var exportInbBtn = new Button();
            exportInbBtn.Text = "Export Inventury";
            exportInbBtn.Click += new EventHandler(myButton_ServerClick);
            ph.Controls.Add(exportInbBtn);
            exportInbBtn.ID = "exportInbBtn";
            return ph;
        }
        private void AddControl()
        {
            var actualObject = (PlaceHolder)getControl();
            phTest.Controls.Add(actualObject);
            controlLoaded.Value = "1";
        }
