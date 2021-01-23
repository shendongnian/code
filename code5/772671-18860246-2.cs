    // Population Standard Deviation
    public void populationStandardDev()
    {
        Double average = lista.Average();
        Double sum = 0;
        foreach (var item in lista)
        {
            Double difference = item - average;
            sum += difference*difference;
        }
        Double sumProd = sum / lista.Count(); // divide by n
        Double desvE = Math.Sqrt(sumProd);
    }
    
    // Standard deviation
    public void standardDev()
    {
        Double average = lista.Average();
        Double sum = 0;
        foreach (var item in lista)
        {
            Double difference = item - average;
            sum += difference*difference;
        }
        Double sumProd = sum / (lista.Count()-1); // divide by n-1 
        Double desvE = Math.Sqrt(sumProd);
    }
