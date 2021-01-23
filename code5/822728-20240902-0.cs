    static void AddClosingTag()
    {
        string input = "This is some content <input type='readonly' value='value1'> and there is further content. This is some additional <input type='readonly' value='value2'> text and then there is further text.";
        int index = 0;
            
        while (true)
        {
            index = input.IndexOf("<input", index);
            if (index == -1)
            {
                break;
            }
            index = input.IndexOf(">", index);
            input = input.Insert(index + 1, "</input>");
        }
        Console.WriteLine(input);
    }
