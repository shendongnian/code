    private void bierButton_Click(object sender, EventArgs e)
    {
        int height = 1;
        int padding = 10;
        int i = 0;
        int x = 0;
        CheckBox[] chk = new CheckBox[10];
        NumericUpDown[] nmr = new NumericUpDown[10];
        orderBox.Clear();
        hideBtn();
        foreach (string bieren in Drinks.bier)
        {
            chk[i] = new CheckBox();
            nmr[i] = new NumericUpDown();
            chk[i].Name = i.ToString();
            chk[i].Text = bieren; // Drinks.bier[i];
            chk[i].TabIndex = i;
            chk[i].AutoCheck = true;
            chk[i].Bounds = new Rectangle(10, 0 + padding + height, 200, 22);
            // Start New Code
            nmr[i].Bounds = new Rectangle(10, 0 + padding + height, 200, 22);
            // End New Code
            panel1.Controls.Add(chk[i]);
            testPanel.Controls.Add(nmr[i]);
            height += 22;
            i++;
        }
    }
