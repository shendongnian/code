        // Start by calling a parent control containing the controls you want to 
        // destroy such as a form, groupbox or panel
        private void DisposeControls(Control ctrl)
        {
            // Make control disappear first to avoid seeing each child control 
            // disappear. This is optional (if you use - make sure you set parent 
            // control's Visible property back to true if you create controls 
            // again)
            ctrl.Visible = false;
            for (int i = ctrl.Controls.Count - 1; i >= 0; i--)
            {
                Control innerCtrl = ctrl.Controls[i];
                if (innerCtrl.Controls.Count > 0)
                {
                    // Recurse to drill down through all controls
                    this.DisposeControls(innerCtrl);
                }
                innerCtrl.Dispose();
            }
        }
