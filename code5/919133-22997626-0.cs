    static async Task<List<string>> MyAsync() {
        List<string> results = new List<string>();
        // One at a time, but each asynchronously...
        for (int i = 0; i < 10; i++) {
            // Or use LINQ, with rather a lot of care :)
            results.Add(await SomeMethodReturningString(i));
        }
        return results;
    }
