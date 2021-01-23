    public class Test
    {
        public async Task Delay()
        {
            await Task.Delay(1000);
            //<-- This "Code" needs to run before my Task is completed
        }
    }
