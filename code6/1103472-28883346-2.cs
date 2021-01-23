     private void button1_Click(object sender, EventArgs e)
    {
      int sizeOfArrayInt = Convert.ToInt32(arraySize.Text);
      int[] array = new int[sizeOfArrayInt];
      string numbers = arrayValues.Text;
      string[] numbersSplit = numbers.Split(',');
      int count = 0;
      foreach (string character in numbersSplit)
      {
        int value;
        bool parse = Int32.TryParse(character, out value);
        if (value != null)
        {
          array[count] = value;
        }
        count++;
      }
      array = this.SortArray(array);
      foreach (int item in array)
      {
        this.listBox.Items.Add(item);
      }
    }
    private int[] SortArray(int[] arrayToSort)
    {
      //int[] sortedArray = new int[arrayToSort.Length];
      int count = arrayToSort.Length;
      for (int j = count; j >= 0; j--)
      {
        int i = 0;
        for (i = 0; i <= j - 2; i++)
        {
          if (arrayToSort[i] < arrayToSort[i + 1])
          {
            int intTemp = 0;
            intTemp = arrayToSort[i];
            arrayToSort[i] = arrayToSort[i + 1];
            arrayToSort[i + 1] = intTemp;
          }
        }
      }
      return arrayToSort;
    }
