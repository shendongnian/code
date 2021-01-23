    for (int i = 0; i < Whatever; ++i)
    {
        string password = ToPasswordString(pwArray, Alphabet);
        // do something with the password
    }
    string ToPasswordString(int[] pass, string alphabet)
    {
        for (int i = pass.Length-1; i > 0; --i)
        {
            pass[i]++;
            if (pass[i] < alphabet.Length)
            {
                break;
            }
            pass[i] = 0;
        }
        var sb = new StringBuilder();
        for (int i = 0; i < pass.Length; ++i)
        {
            if (pass[i] >= 0)
                sb.Append(alphabet[pass[i]]);
        }
        return sb.ToString();
    }
