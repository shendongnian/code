    class Program
    {
        static void Main(string[] args)
        {
            int g;
            g = Equation(75, 25);
            Console.WriteLine(g);
        }
    
        static int Equation(int Damage, int Temp)
        {
            if (Temp > 0)
            {
                int a, b, c;
                a = Damage / 2;
                b = a + Temp;
                c = b - 50;
                return c;
    
            }
            else
            {
                int d, e, f;
                d = Damage / 2;
                e = d - Temp;
                f = e - 50;
                return f;
            }
    
        }
    }
