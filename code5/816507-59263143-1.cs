java
    using System;
    
    namespace RoomPaintCost
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("This program applies quadratic formula to Ax^2+Bx+C=0 problems");
    
                double[] ABC= getABC();
                double[] answerArray=QuadFormula(ABC);
    
                Console.WriteLine("Positive answer: {0:0.000} \n Negative answer: {1:0.000}", answerArray[0], answerArray[1]);
    
            }
    
            //Form of Ax^2 + Bx + C
            //Takes array of double containing A,B,C 
            //Returns array of positive and negative result
            public static double[] QuadFormula(double[] abc)
            {
                NotFiniteNumberException e = new NotFiniteNumberException();
               
                try
                {
                    double a = abc[0];
                    double b = abc[1];
                    double c = abc[2];
                    double discriminant = ((b * b) - (4 * a * c));
                    if (discriminant < 0.00)
                    {
                        throw  e; 
                    }
                    
                    discriminant = (Math.Sqrt(discriminant));
                    Console.WriteLine("discriminant: {0}",discriminant);
                    double posAnswer = ((-b + discriminant) / (2 * a));
                    double negAnswer = ((-b - discriminant) / (2 * a));
    
                    double[] xArray= { posAnswer,negAnswer};
                    return xArray;
    
                }
                catch (NotFiniteNumberException)
                {
                    Console.WriteLine("Both answers will be imaginary numbers");
                    double[] xArray = { Math.Sqrt(-1), Math.Sqrt(-1) };
                    return xArray;
                }
    
            }
    
            public static double[] getABC()
            {
                
                Console.Write("A=");
                string sA = Console.ReadLine();
                Console.Write("B=");
                string sB = Console.ReadLine();
                Console.Write("C=");
                string sC = Console.ReadLine();
    
                int intA = Int32.Parse(sA);
                int intB = Int32.Parse(sB);
                int intC = Int32.Parse(sC);
                double[] ABC = { intA, intB, intC };
    
                
    
                return ABC;
            }
        }
    }
