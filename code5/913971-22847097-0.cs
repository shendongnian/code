        List<Control> AllFormsControl = new List<Control>();
        public void InitContolList(Control nControl)
        {
            if (nControl.Controls.Count > 0)
            {
                foreach (Control item in nControl.Controls)
	            {
		             InitContolList(item);
                    AllFormsControl.Add(item);
	            }
                
            }
          // Optional
          //AllFormsControl.Add(nControl);
        }
