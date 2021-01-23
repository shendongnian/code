	List<int> randomNumbers = Enumerable.Range(0,10).ToList();
	Random newNumberGenerator = new Random();
	do
    {
        int index = newNumberGenerator.Next(0, randomNumbers.Count);
        dialogResult = MessageBox.Show("Is number" + randomNumbers[index] + " you are thinking about?", "Answer the question!", MessageBoxButtons.YesNo);
        if(dialogResult==DialogResult.No)
        {
            randomNumbers.RemoveAt(index);
        }
    }
    while (dialogResult == DialogResult.No);
