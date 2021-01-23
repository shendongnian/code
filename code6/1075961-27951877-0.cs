    int[] alphabetCount =
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    string baseInput = string.Empty;
    private void button_count1_Click(object sender, EventArgs e)
    {
        baseInput = textBox_base.Text.ToUpper();
        
        foreach(var character in baseInput)
        {
            if(char.IsLetter(baseInput))
            {
                // A is ASCII 65, Z is ASCII 90
                // Subtract 65 to put it in the alphabetCount range
                var index = character - 65;
                alphabetCount[index]++;
            }
        }
    }
