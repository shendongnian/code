    private void btnDisplay_Click(object sender, EventArgs e)         
    {
       if (String.IsNullOrEmpty(txtScore.Text))
       {
         MessageBox.Show("Please Enter a number");
       }
       else
       {
          Scores.Sort(); // Scores being sorted out from low to high numbers. 
          string value = string.Empty; // String value is assigned. 
          int count = 0;
          for (count = 0; count < Scores.Count; count++) // Arranges the scores from low to high numbers. 
          {
            value += Scores[count] + "\n"; // Incrementing each value and adding the scores to the list.
            // "\n" inserts a new line between each score. 
          }
          MessageBox.Show(value.ToString());
       }
    }
