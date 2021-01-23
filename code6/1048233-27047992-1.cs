    private void displayTemps()
    {
        string strLine;
        lstTemp.Items.Clear();
        double[] dblAverages = new double[5];
        int intNonBlank = 0;
    
        for (int l = 0; l <= 4; l++)
        {
            intNonBlank = 0;
            for (int c = 0; c <= 3; c++)
            {
                if (intTemps[l, c] != 0)
                {
                    dblAverages[l] += intTemps[l, c];
                    intNonBlank++;
                }
            }
            if (intNonBlank != 0)
            {
                dblAverages[l] /= intNonBlank;
            }
            int min_temp = System.Linq.Enumerable.Range(0, 4).
                Select(i => intTemps[l, i]).Min();
            int max_temp = System.Linq.Enumerable.Range(0, 4).
                Select(i => intTemps[l, i]).Max();
            lstTemp.Items.Add(
                "Average temp for city "+ l +": " + dblAverages[l] + " " + 
                "Minimum " + min_temp + " " + 
                "Maximum " + max_temp);
        }           
    }
