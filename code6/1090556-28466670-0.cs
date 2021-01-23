    string text = "123456789"; //Set to TextBox text
    int[] numbers = new int[text.Length]; //Create array of ints
    for (int i = 0; i < text.Length; i++)
    {
        //Parse each character to an integer
        numbers[i] = Int32.Parse(text[i].ToString());
    }
