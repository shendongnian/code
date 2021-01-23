     string ans = "";
            double root1 = 0;
            double root2 = 0;
            double b = 0;
            double a = 0;
            double c = 0;
            double identifier = 0;
            
            a =Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            c = Convert.ToDouble(Console.ReadLine());
            identifier = b * b - (4 * a * c);
            if (identifier > 0)
            {
                root1 = (-b+(Math.Sqrt(identifier)/(2*a)));
                root2 = (-b - (Math.Sqrt(identifier) / (2 * a)));
                string r1 = Convert.ToString(root1);
                string r2 = Convert.ToString(root2);
                ans = "Root1 =" + r1 + "Root2 = " + r2;
                Console.WriteLine(ans);
            }
            if (identifier < 0)
            {
                double Real = (-b / (2 * a));
                double Complex = ((Math.Sqrt((identifier*(-1.00))) / (2 * a)));
                string SReal = Convert.ToString(Real);
                string SComplex = Convert.ToString(Complex);
                ans = "Roots = " + SReal + "+/-" + SComplex + "i";
                Console.WriteLine(ans);
            }
 
            if (identifier == 0)
            {
                root1 = (-b / (2 * a));
                string Root = Convert.ToString(root1);
                ans = "Repeated roots : " + Root;
            }
