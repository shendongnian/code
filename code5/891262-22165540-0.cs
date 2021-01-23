    // String is immutable; copy to a char[] so we can modify that in-place
    char[] chars = input.ToCharArray();
    for (int i = 0; i < chars.Length; i += 3)
    {
        chars[i] = char.ToUpper(chars[i]);
    }
    // Now construct a new String from the modified character array
    string output = new string(chars);
