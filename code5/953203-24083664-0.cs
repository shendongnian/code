        protected void Page_PreInit(object sender, EventArgs e)
        {
            foreach (Control c in HWControls)
            {
                if(c.ID.Contains("ciDD"))
                {
                    ((DropDownList)c).SelectedIndexChanged += new EventHandler(this.ciDD_SelectedIndexChanged);
                }
                else if (c.ID.Contains("deviceTypeDD"))
                {
                    ((DropDownList)c).SelectedIndexChanged += new EventHandler(this.deviceTypeDD_SelectedIndexChanged);
                }
            }
        }
