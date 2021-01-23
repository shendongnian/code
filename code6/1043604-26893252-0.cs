    static double GetGradesSum(double[] grades)
    {
        double sum = 0;
        for(int i = 0; i < grades.Length; i++)
            sum += grades[i];
        return sum;
    }
