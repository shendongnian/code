        public static double CalculateRsi(IEnumerable<double> closePrices)
        {
            var prices = closePrices as double[] ?? closePrices.ToArray();
            double sumGain = 0;
            double sumLoss = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var difference = prices[i] - prices[i - 1];
                if (difference >= 0)
                {
                    sumGain += difference;
                }
                else
                {
                    sumLoss -= difference;
                }
            }
            if (sumGain == 0) return 0;
            if (Math.Abs(sumLoss) < Tolerance) return 100;
            var relativeStrength = sumGain / sumLoss;
            return 100.0 - (100.0 / (1 + relativeStrength));
        }
