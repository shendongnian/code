            try
            {
                nomreList = new List<double>();
                adjustmentsVal = 0;
                completed = false;
                int count = workBookData.NumberStudents;
                double min = workBookData.Min;
                double max = workBookData.Max;               
                double target = workBookData.FixedAvg;
                double tolerance = workBookData.Tolerance;
                double minAverage = Math.Round(target - tolerance, 2);
                double maxAverage = Math.Round(target + tolerance, 2);
                Random r = new Random(DateTime.Now.Millisecond);
                List<double> listNomre = new List<double>();
                double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    double d = Math.Round(RangedDouble(min, max, r), 2);
                    listNomre.Add(d);
                    sum += d;
                    sum = Math.Round(sum, 2);
                }
                int adjustments = 0;
                while (Math.Round((sum / count), 2) < minAverage || Math.Round((sum / count), 2) > maxAverage)
                {
                   
                    if (Math.Round((sum / count), 2) < minAverage)
                    {
                        double oldDbl1 = listNomre.First(d => d < minAverage);
                        //min<a1+x1<max --> a1 is oldDbl1 , x1 --> Unknown
                        double newDbl1 = Math.Round(oldDbl1 + RangedDouble(min-oldDbl1, max - oldDbl1, r), 2);
                        listNomre.Remove(oldDbl1);
                        sum -= oldDbl1;
                        sum = Math.Round(sum, 2);
                        listNomre.Add(newDbl1);
                        sum += newDbl1;
                        sum = Math.Round(sum, 2);
                        adjustments++;
                        continue;
                    }
                    double oldDbl = listNomre.First(d => d > maxAverage);
                    //min<a1-x1<max --> a1 is oldDbl , x1 --> Unknown
                    double newDbl = Math.Round(oldDbl - RangedDouble(oldDbl-max, oldDbl - min, r), 2);
                    listNomre.Remove(oldDbl);
                    sum -= oldDbl;
                    sum = Math.Round(sum, 2);
                    listNomre.Add(newDbl);
                    sum += newDbl;
                    sum = Math.Round(sum, 2);
                    adjustments++;
                }
                nomreList = listNomre;
                adjustmentsVal = adjustments;               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        private static double RangedDouble(double min, double max, Random r)
        {
            //Function RangedDouble => Random Number Between 2 Double Numbers
            //Random.NextDouble => returns a double between 0 and 1
            return Math.Round( r.NextDouble() * (max - min) + min,2);
        }
