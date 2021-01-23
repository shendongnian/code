     private void txtPenaltyDays_TextChanged(object sender, EventArgs e)
     {
       short num;
       if(!Int16.TryParse(txtPenaltyDays.Text, out num))
       {
           if(num > 5)
           {
               txtPenaltyDays.TextChanged -= txtPenaltyDays_TextChanged;
               MessageBox.Show("The maximum amount in text box cant be more than 5"); 
               txtPenaltyDays.Text = "0";//
               txtPenaltyDays.TextChanged += txtPenaltyDays_TextChanged;
           }
       }
       else
       {
          txtPenaltyDays.TextChanged -= txtPenaltyDays_TextChanged;
          MessageBox.Show("Typed an invalid character- Only numbers allowed"); 
          txtPenaltyDays.Text = "0";
          txtPenaltyDays.TextChanged += txtPenaltyDays_TextChanged;
       }
     }
