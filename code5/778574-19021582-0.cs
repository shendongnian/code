       public List<string> NoOfControls
        {
            get
            {
                return ViewState["NoOfControls"] == null ? new List<string>() : (List<string>)ViewState["NoOfControls"];
            }
            set
            {
                ViewState["NoOfControls"] = value;
            }
        }
        protected override void LoadViewState(object savedState)
        {
            base.LoadViewState(savedState);
            GenerateControls();
        }
        private void GenerateControls()
        {
            foreach (string i in NoOfControls)
            {
                var ctrl = (AddVisaUserControl)LoadControl(@"AddVisaUserControl.ascx");
                ctrl.ID = i;
                this.AddVisaPlaceHolder.Controls.Add(ctrl); // Add in placeholder
            }
        }
        //Adding controls to Place Holder
        protected void AddButton_Click(object sender, EventArgs e)
        {
           
            List<string> temp = null;
            var uc = (AddVisaUserControl)this.LoadControl(@"AddVisaUserControl.ascx");
            string id = Guid.NewGuid().ToString();
            uc.ID = id;
            temp = NoOfControls;
            temp.Add(id);
            NoOfControls = temp;
            AddVisaPlaceHolder.Controls.Add(uc);
        }
        //Save
        protected void Save_Click(object sender, EventArgs e)
        {
            foreach (var control in AddVisaPlaceHolder.Controls)
            {
                var usercontrol = control as AddVisaUserControl;
            
              //you can access properties from usercontrol
                //Implement save logic here
            }
        }
