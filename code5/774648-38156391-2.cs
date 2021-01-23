    //I didn't refactored the names of the variables N and A
    //to maintain it aligned with the question description
    public int[] solution(int N, int[] A)
    {
        var counters = new Counters(N);
        for (int k = 0; k < A.Length; k++)
        {
            if (A[k] <= N)
                counters.IncreaseCounter(A[k]);
            else
                counters.MaxAllCounters();
        }
        return counters.ToArray();
    }
    
    public class Counters
    {
        private int[] counters;
        private int greaterValueInCounter = 0;
        public Counters(int length)
        {
            counters = new int[length];
        }
        public void MaxAllCounters()
        {
            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = greaterValueInCounter;
            }
        }
        public void IncreaseCounter(int counterPosition)
        {
            //The counter is one-based, but our array is zero-based
            counterPosition--;
            //Increments the counter
            counters[counterPosition]++;
            if (counters[counterPosition] > greaterValueInCounter)
                greaterValueInCounter = counters[counterPosition];
        }
        //The counters array is encapsuled in this class so if we provide external 
        //acess to it anyone could modify it and break the purpose of the encapsulation
        //So we just exposes a copy of it :)
        public int[] ToArray()
        {
            return (int[])counters.Clone();
        }
    } 
