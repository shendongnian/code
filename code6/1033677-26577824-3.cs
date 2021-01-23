        private static async Task TestNullCase()
        {
            // This does not throw a TaskCanceledException
            await Task.Run(() => 5);
            // This does throw a TaskCanceledException
            await Task.Run(() => GetNull());
        }
        private static object GetNull()
        {
            return null;
        }
