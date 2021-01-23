        public class OddAndPrimeCounter : IOddNumberCounter, IPrimeNumberCounter
        {
            int IOddNumberCounter.Count(params int[] input)
            {
                //count the odds
            }
            int IPrimeNumberCounter.Count(params int[] input)
            {
                //count the primes
            }
        }
