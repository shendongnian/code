    private void a1calculate(char number)
    {
        bool plausible = true;
        for (int i = 0; i < 9; i++)
        {                
            var a = hello('a');
            if (a[i].Text[0] == number && a[i].Text.Length == 1) { plausible = false; }
        }
    }
