    [HttpPost]
        public void MyAction(string value)
        {
            Session["myKey"] = value;
        }
