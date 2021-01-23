    public void calculaDesviacionE()
    {
        Double average = lista.Average();
        Double sum = 0;
        foreach (var item in lista)
        {
            Double difference = item - average;
            sum += difference*difference;
        }
        Double sumProd = sum / lista.Count();
        Double desvE = Math.Sqrt(sumProd);
    }
