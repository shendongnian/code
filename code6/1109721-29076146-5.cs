        private void CreateDynamicControls()
        {
            List<string> optionList = new List<string> { "opt1", "opt2", "opt3" };
            foreach (string row in optionList)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.ID = "reason_" + row;
                radioButton.GroupName = "reason";
                radioButton.Text = row;
                this.Form.Controls.Add(radioButton);
            }
        }
