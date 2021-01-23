        void DDL_SelectChanged(object sender, EventArgs e)
        {
            if (DDL1.SelectedIndex == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    TextBox newTB = new TextBox();
                    newTB.ID = "TB" + i;
                    PH1.Controls.Add(newTB);
                }
            }
        }
