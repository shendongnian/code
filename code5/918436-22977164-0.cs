    int[,] A = new int[3, 4] 
    { 
        { 4, -5, 12, -2},
        { -9, 15, 19, 6},
        { 18, -33, -1, 7}
    };
      private void TotArray(int[,] array) 
      {
          int sum = 0;
          int rows = array.GetLength(0);
          int cols = array.GetLength(1);
          for (int i = 0; i < rows; i++)
          {
              for (int j = 0; j < cols; j++)
              {
                  sum += A[i, j];
              }
          }
          MessageBox.Show("The sum of the array is " + sum.ToString() + "."); //Show the sum
       }
    private void button1_Click(object sender, EventArgs e)
    {
        TotArray(A);
    }
