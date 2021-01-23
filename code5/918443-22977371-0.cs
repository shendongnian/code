    private int TotArray(int[,] array)
    {
        int sum = 0;
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += array[i, j];
            }
        }
        return sum;
    }
    private void button1_Click(object sender, EventArgs e)
    {
       int sum = TotArray(A);
       richTextBox1.Text = ("The sum of the array is " + sum.ToString() + ".");
    }
