    // Assuming textBoxArr[], labelArr[], userValueArr are globals (not sure what class types)
    private void gatherTextBoxdata()
    {
        for(int i = 0; i < textBoxArr.Length; i++)
        {
            if (Double.TryParse(textBoxArr[i].Text))
            {
                labelArr[i].Text = Convert.ToString(Math.Sqrt(doubleUserValueArr[i]));
            }
            else
           {
                labelArr[i].Text = textBoxArr[i].Text + " is not a number";
           }
    }
