            //Method to ensure the visibility of a control
            public bool DetermineVisibility(Control control)
            {
                //Return true if control is visible
                if (control.Visible)
                    return true;
    
                //Find non-public GetState method of control using reflection
                System.Reflection.MethodInfo GetStateMethod = control.GetType().GetMethod("GetState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    
                //return control's visibility if GetState method not found
                if (GetStateMethod == null) return control.Visible;
    
                //return visibility from the state maintained for control
                return (bool)(GetStateMethod.Invoke(control, new object[] { 2 }));
            }
    
            //Exporting child controls to bitmap based on visibility
            private void ExportChildControls(Bitmap bmp)
            {
                foreach (Control control in this.Controls)
                {
                    if (DetermineVisibility(control))
                        control.DrawToBitmap(bmp, control.ClientRectangle);
                }
            }
