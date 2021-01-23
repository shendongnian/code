    char[] split = new char[] { ',' };
    StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries;
    string[] first = ConjTextBox.Text.Split(split, options);
    string[] second = DisjTextBox.Text.Split(split, options);
    int[] intsInFirstTextBox = Array.ConvertAll(first, s => int.Parse(s));
    int[] intsInSecondTextBox = Array.ConvertAll(second, s => int.Parse(s));
    int[] ListOfInts = intsInFirstTextBox.Intersect(intsInSecondTextBox);
