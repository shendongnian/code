        string[] alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string inVAR = textBox1.Text.ToUpper();
        string outVAR;
        StringBuilder sb = new StringBuilder(inVAR);
        foreach (char c in inVAR) // inVAR because stringbuilders won't work with foreach
        {
            if (!alpha.Contains(c))
            {
                sb[i] = ' ';
            }
        }
        outVAR = sb.ToString();
