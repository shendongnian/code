     double[] tmpArray = StringToDoubleArray("12,13,14");
     private static double[] StringToDoubleArray(string strNumbers)
            {
                List<double> dblValues = new List<double>();
                Array.ForEach(strNumbers.Split(",".ToCharArray()), s =>
                {
                    double currentDouble;
                    if (Double.TryParse(s, out currentDouble))
                        dblValues.Add(currentDouble);
                });
                return dblValues.ToArray();
            } 
