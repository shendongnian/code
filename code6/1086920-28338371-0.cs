    public void FocusControl(string controlName)
        {
            var controls = this.Controls.Find(controlName, true);
            if (controls != null && controls.Count() == 1)
            {
                controls.First().Focus();
            }
        }
