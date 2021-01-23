        private async void button1_Click(object sender, EventArgs e)
        {
            IAsyncEnumerable<int> enumerable = GenerateSequence();
            await foreach (var i in enumerable)
            {
                Debug.WriteLine(i);
            }
        }
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 20; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
