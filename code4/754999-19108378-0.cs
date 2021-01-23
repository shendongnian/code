    public static class ExpensiveTasks
    {
        public static IEnumerable<KeyValuePair<String, int>> ExpensiveTask1(int sleepTime)
        {
            for (int i = 1; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(sleepTime);
                yield return new KeyValuePair<String, int>("Reporting Progress", i);
            }
        }
    }
