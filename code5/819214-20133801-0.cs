    int[] numbers = new int[lstBubbleUnorderd.Items.Count];
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = int.Parse(lstBubbleUnorderd.Items[i].ToString());
    }
    for (int y = 0; y < numbers.Length; y++)
    {
        for (int i = numbers.Length - 1; i > y; --i)
        {
            if (numbers[i] <= numbers[i - 1])
            {
                int temp = numbers[i];
                numbers[i] = numbers[i - 1];
                numbers[i - 1] = temp;
            }
        }
    }
    for (int j = 0; j < numbers.Length; j++)
    {
        lstBubbleOrderd.Items.Add(numbers[j]);
    }
