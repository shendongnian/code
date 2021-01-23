    var input = "a1b2c3d4e5f6g7h8i9j1k2l3m4";
    int ixLetter = 0;
    int ixDigit = input.Length - 1;
    int oxLetter = 0;
    int oxDigit = input.Length - 1;
    char[] output = new char[input.Length];
    while (ixDigit >= 0)
    {
        if (char.IsDigit(input[ixDigit]))
        {
            output[oxDigit] = input[ixDigit];
            --oxDigit;
        }
        if (!char.IsDigit(input[ixLetter]))
        {
            output[oxLetter] = input[ixLetter];
            ++oxLetter;
        }
        --ixDigit;
        ++ixLetter;
    }
    string result = new string(output);
