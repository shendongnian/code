    int y=20;
    for (int i = 0; i < grpbxVals.Count-1; i++)
        {
            radbtn = new RadioButton();
            radbtn.Text = grpbxVals[i];
            radbtn.Location=new System.Drawing.Point(6, y);
            y+=radbtn.Height;
            gb.Controls.Add(radbtn);
            radbtn = null;
        }
