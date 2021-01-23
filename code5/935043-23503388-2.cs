    using (StreamWriter st = new StreamWriter(filePath))
    {
       for (int row = 0; row < arr.GetLength(0); row++)
       {
           for (int col = 0; col < arr.GetLength(1); col++)
           {
                st.Write(arr[row,col] + " ");
           }
           st.WriteLine();
       }
    }
