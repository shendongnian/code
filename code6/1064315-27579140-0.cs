    [TestClass]
    public class AsyncTest
    {
        [TestMethod]
        public async Task RunTest_1()
        {
            var result = await GetStringAsync();
            Console.WriteLine(result);
        }
        private async Task AppendLineAsync(StringBuilder builder, string text)
        {
            await Task.Delay(1000);
            builder.AppendLine(text);
        }
        public async Task<string> GetStringAsync()
        {
            // Code before first await
            var builder = new StringBuilder();
            var secondLine = "Second Line";
            // First await
            await AppendLineAsync(builder, "First Line");
            // Inner synchronous code
            builder.AppendLine(secondLine);
            // Second await
            await AppendLineAsync(builder, "Third Line");
            // Return
            return builder.ToString();
        }
    }
