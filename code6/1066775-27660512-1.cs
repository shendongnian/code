    private void btnShow_Click(object sender, EventArgs e)
    {
        btnShow.Text = "Hide";
    
      	int[] numbers = PickIntegers(3, RandomColor.Length);
      	
      	pnlNPC1.BackColor = RandomColor[numbers[0]];
        pnlNPC2.BackColor = RandomColor[numbers[1]];
        pnlNPC3.BackColor = RandomColor[numbers[2]];
     
      	
        pnlNPC1.Visible = true;
        pnlNPC2.Visible = true;
        pnlNPC3.Visible = true;
     }
