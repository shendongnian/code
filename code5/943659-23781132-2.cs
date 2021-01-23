    for (int i = 0; i < message.Length(); i++)
    {
        if (message[i] < 123 && message[i] > 96)
        {
            // 97 to 122 are 'a' to 'z'
            message[i] += 3;
            if (message[i] > 122)
            {
                message[i] -= 26;
            }
        }
    }
    EDIT: XOR-encryption:
    string codeword = "word";
    string res = "";
    for (int i = 0; i < message.Length(); i++)
    {
        res += (char)(message[i] ^ codeword[i % codeword.Length()]);
    }
