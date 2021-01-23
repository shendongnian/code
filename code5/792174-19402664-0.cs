    public class Calculations
    {
        public static int[] arrayCalculator(int m)
        {
            int i; 
            int[] result = new int[9];   
            int[] timesTable = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (i = 0; i <= 9; i++)
            {                result[i] = m * timesTable[i];
                System.Diagnostics.Debug.WriteLine("Calculation successful: " + m + " * " +  timesTable[i] + " = " + result[i] + "."); 
           }
            return result; // returns int result[]
        }
    }
