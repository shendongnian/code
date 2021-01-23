        Dictionary<System.Web.UI.WebControls.Button, string> ButtonToURIMap = new Dictionary<System.Web.UI.WebControls.Button, string>();
        private void AddButtonToForm()
        {
            System.Web.UI.WebControls.Button myWebButton = new System.Web.UI.WebControls.Button();
            //Initialize/Style your button here.
            myWebButton.Click +=myWebButton_Click;
            ButtonToURIMap.Add(myWebButton, "http://www.google.com/");
        }
        void myWebButton_Click(object sender, EventArgs e)
        {
            if (sender is System.Web.UI.WebControls.Button)
            {
                System.Web.UI.WebControls.Button callingButton = (System.Web.UI.WebControls.Button)sender;
                if ( ButtonToURIMap.ContainsKey(callingButton))
                {
                    string uri = ButtonToURIMap[callingButton];
                    //code you execute from here
                }
            }
        }
