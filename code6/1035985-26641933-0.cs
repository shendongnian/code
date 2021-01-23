    var percentages = new List<double>(new double[3]);
    
    PrintCombinations(percentages, 0, 1.0);
    private void PrintCombinations(List <double> list, int i, double r) {
        double x = 0.0;
        if (list.Count > i + 1) {
            while (x < r + 0.01) {
                list[i] = x;
                PrintCombinations(list, i+1, r-x);
            }
        }
        else {
            list[i] = r;
            percentages.ForEach(x => Console.Write("{0}\t", x));
            Console.WriteLine();
        }
    }
