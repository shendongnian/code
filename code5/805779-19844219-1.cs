    string dika = Textbox1.Text;
        int countDot = 0;
        for (int i = 0; i < dika.Length; i++)
        {
            if (dika[i] == '.')
            {
                countDot++;
                if (countDot > 1)
                {
                    dika = dika.Remove(i, 1); 
                    i--;
                    countDot--;
                }
            }
        }
    Textbox1.Text = dika;
    Textbox1.Select(dika.Text.Length, 0);
