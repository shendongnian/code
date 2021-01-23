    public static double RoundToFactor(double Number, int Factor, bool RoundDirection = true)
        {/*round direction: in the event that the distance is 
          * equal from both next factors round up (true) down (false)*/
          
            double multiplyBy;
            if ((Number % Factor).Equals(0f))
            {
                return Number;
            }
            else
            {
                multiplyBy = Math.Round(Number / Factor);
                int Low = (int)multiplyBy - 1;
                int Mid = (int)multiplyBy;
                int High = (int)multiplyBy + 1;
                List<double> li = new List<double>() { Low, Mid, High };
                double minDelta = double.MaxValue;
                double Closest = 0d;
                foreach (double dbl in li)
                {
                    double db = dbl * Factor;
                    double Delta = (db < Number) ? (Number - db) : (db - Number);
                    if (RoundDirection ? Delta <= minDelta : Delta < minDelta)
                    {
                        minDelta = Delta;
                        Closest = db;
                    }
                }
                return Closest;
            }
            
            throw new Exception("Math has broken!!!");
        }
