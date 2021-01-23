    List<Control> lst_controls = new List<Control>();
            public void btnClick()
            {
                 RetrieveAllControls(this.Page);
                 foreach(Control contrl in lst_controls)
                 {
                         // all controls 
                 }
            }
            public static void RetrieveAllControls(Control control)
            {
                foreach (Control ctr in control.Controls)
                {
                    if (ctr != null)
                    {
                                   
                        lst_controls.add(ctr);             
                        if (ctr.HasControls())
                        {
                            RetrieveAllControls(ctr, strID);
                            
                        }
                    }
                }
                return null;
            }
