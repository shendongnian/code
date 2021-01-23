    public class Model
    {
        public async Task<int> GetDataAsync()
        {
            // Simulate work done on the web service
            await Task.Delay(1000);
            return new Random(Environment.TickCount).Next(1, 100);
        }
    }
