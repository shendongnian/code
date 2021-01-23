    if (int.TryParse(txtAnswer.Text, userguess))
    {
            if (userguess == answer)
            {
                // If the player's answer is correct, an appropriate message is displayed and 1 point added to the kill-score. 
                lblResult.Text = "# Enemy charge calculated correctly, charge bounced back and damage evaded.";
                lblRight.Text = (System.Convert.ToInt32(lblRight.Text) + 1).ToString();
            }
            else
            {
                // If the player's answer is incorrect, an appropriate message is displayed and 100 points are added to the damages cost counter. 
                lblResult.Text = "# Enemy charge calculated incorrectly, charge fired and hit! The charge had " + answer.ToString() + " power units applied.";
                lblWrong.Text = (System.Convert.ToInt32(lblWrong.Text) + 100).ToString();
            }
            // After appropriate action has been taken based on the player's answer, a new sum is generated. 
            makeNewSum();				
    }
    else{
        lblResult.Text = "Incorrect value!";
    }
