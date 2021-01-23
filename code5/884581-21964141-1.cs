    public class Newton_Ralphson
    {
        public static double compute(double x, int n, double[] P) // x, degree, coefficients 
        {
            double pol = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j < n - i; j++)
                    x *= x;
                pol += P[n - i]*x;
            }
            pol += P[0];
            return pol;
        }
    
        public static double[] secondary_Pol(int n, double[] P) //slope
        {
            double[] secP = new double[n - 1];
            for (int i = 0; i < n - 1; i++)
                secP[i] = P[i + 1];
            return secP;
        }
    
        public static void Main()
        {
            Console.WriteLine("Estimate the solution for a nth degree polynomial!!! ");
            int n = 0;
            Console.WriteLine("Enter the degree of the polynomials! ");
            n = Int32.Parse(Console.ReadLine());
            double[] coefficients = new double[n + 1];
    
            for (int i = 0; i < n + 1; i++)
            {
                Console.WriteLine("Enter the coefficients ");
                Console.Write("coefficients of x to the power of {0}: ", n - i); //decending coefficients 
                coefficients[n - i] = Convert.ToDouble(Console.ReadLine());
            }
    
    
            Console.WriteLine("Initial value is: ");
            double xint = Convert.ToDouble(Console.ReadLine());
    
            Console.WriteLine("How many times does the function go through? ");
            int precision = Convert.ToInt32(Console.ReadLine());
            double polyValue = 0;
    
            for (int j = 0; j < precision; j++)
            {
                polyValue = compute(xint, n, coefficients); //y0 in y = slope(x-x0) + y0
                double slope = compute(xint, n - 1, secondary_Pol(n, coefficients));
                xint = (-polyValue/slope) + xint;
            }
            Console.WriteLine(xint);
            Console.ReadLine();
    
        }
    }
