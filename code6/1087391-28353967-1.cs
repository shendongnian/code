     foreach (Control c in this.Controls)
      {
                if (c is Label) // Here check if the control is label 
                {
                    c.BackColor = Color.Red; // you code goes here
                    
                }
      }
