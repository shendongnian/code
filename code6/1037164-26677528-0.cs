     for (int i = 0; i < controlObj.Count() - 1; i++)
        {
            int j = i;
            controlObj[i].BeginInvoke((Action)delegate
            {
                if (controlObj[j] is TextBox || controlObj[j] is CheckBox || controlObj[j] is Panel)
                    controlObj[j].Enabled = true;
                else
                {
                    controlObj[j].BackColor = Color.DarkGray;
                    controlObj[j].Enabled = true;
                }
            });
        }
