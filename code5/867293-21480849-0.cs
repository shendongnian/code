    if (allergiesResult > 0)
    {
        if (txtNewAllergy.Text != null || txtReactions.Text != null)
        {
            if (txtNewAllergy.Text == null)
            {
                MessageBox.Show("Please key in the Type of the allergy", "WARNING");
            }
            else if (txtReactions.Text == null)
            {
                MessageBox.Show("Please key in the Description of the allergy", "WARNING");
            }
            else
            {
                // WHAT HAPPENS HERE?
            }
        }
        else
        {
            MessageBox.Show("Submitted, fool");
        }
    }
    else
    {
        MessageBox.Show("Not submitted, fool");
    }
