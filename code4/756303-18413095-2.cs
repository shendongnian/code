    string number = "1800HIETHC"; //Console.ReadLine() reads whole line, not a single char.
    int[] nums = Digits(number);
    static int[] Digits(string number)
    {
        return number.Where(char.IsLetterOrDigit).Select(ToNum).ToArray();
    }
    static int ToNum(char c)
    {
        int[] nums = { 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 9, 9, 9, 9 };
        if (char.IsDigit(c)) return c - '0';
        c = char.ToUpper(c);
        return nums[c - 'A'];
    }
