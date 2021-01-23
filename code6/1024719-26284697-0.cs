    private void txtPenaltyDays_TextChanged(object sender, EventArgs e)
    {
       if(Convert.ToInt16(txtPenaltyDays.Text)>5)
       {
          MessageBox.Show("The maximum amount in text box cant be more than 5"); 
          txtPenaltyDays.TextChanged -= txtPenaltyDays_TextChanged; 
          txtPenaltyDays.Text = 0;// Re- triggers the TextChanged 
          txtPenaltyDays.TextChanged += txtPenaltyDays_TextChanged;
       }
    }
