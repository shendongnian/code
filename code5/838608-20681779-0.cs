    private void butt2_2_Click(object sender, EventArgs e) 
    {
      Button pushedBtn = sender as Button;
      if(pushedBtn != null)
      {
         pushedBtn.BackColor = Color.Green;
      }  
    }
