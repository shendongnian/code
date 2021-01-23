        int[,] arrayA = new int[6, 6]; //max dimensions is a 6x6 matrix
        List<TextBox> listeA = new List<TextBox>();
*
    private void readA(int zeilen, int spalten)
        {
            int counter = 0;
            for (int j = 0; j < zeilen; j++)
            {
                for (int i = 0; i < spalten; i++)
                {
                    arrayA[j, i] = Convert.ToInt32(listeA[counter].Text);
                    counter= counter + 1;
                }
            }
        }
