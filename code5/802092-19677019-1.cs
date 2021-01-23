        private static void WaitForIt(this IAsyncResult result)
        {
            while (!result.IsCompleted)
            {
                Thread.Sleep(50);
            }
        }
