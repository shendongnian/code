    int[,] A = new int[5, 7];
    Random rand = new Random();
    private void SumOdd(int[,] array)
    {
        int sum = 0;
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int value = rand.Next(-100, 100); // Create a new random number.
                array[i, j] = value;  // Store it in the array.
                richTextBox1.AppendText(value + " "); // Display it in the textbox.
                if (value % 2 != 0) // Test if it is odd.
                    sum += value; // If so... add it to the sum.
            }
        }
        richTextBox1.AppendText("The Sum of all Odd is: "+ sum.ToString());
    }
