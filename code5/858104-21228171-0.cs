        for (int i = 0; i < 10; i++)
        {
            lnkArray[i] = new LinkLabel();
            lnkArray[i].Text = "test" + i;
            lnkArray[i].Location = new System.Drawing.Point(20 + (i + 200), 50);
            lnkArray[i].Size = new Size(200, 25);
        }
        panel1.Controls.AddRange(lnkArray);
