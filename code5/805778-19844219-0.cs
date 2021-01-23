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
