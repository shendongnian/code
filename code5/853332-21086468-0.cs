     myDynCheckBox.CheckedChanged += CBCheckedChanged;
            private void CBCheckedChanged(object sender, EventArgs e)
            {
                var temp = sender as CheckBox;
                if (temp != null)
                {
                    if (temp.Checked)
                    {
                        MyButton.Enabled = false;
                    }
                    else
                    {
                        MyButton.Enabled = true;
                    }
                }
            }
