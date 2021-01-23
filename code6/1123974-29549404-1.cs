    private void Get_Gender(List<RadioButton> genderButtons)
    {
        foreach (var genderButton in genderButtons)
        {
            if (genderButton.Checked)
            {
                return genderButton.Text;
            }
         }
     }
