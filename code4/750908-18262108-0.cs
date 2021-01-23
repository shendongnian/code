    CheckBox[] chk;
    chk = new CheckBox[10];
    for (int i = 0; i <= 9; i++)
    {
      chk[i] = new CheckBox();
      chk[i].Name = i.ToString();
      chk[i].Text = i.ToString();
      chk[i].TabIndex = i;
     chk[i].AutoCheck=true;
      panel1.Controls.Add(chk[i]);
    }
     
 
     
