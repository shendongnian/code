    public async Task<int> CalcSomething()
    {
        return Task<int>.Factory.StartNew(() => {
            var result = 0;
            while (...) {
                result++;
            }
            return result;
        });
    }
    public async void MyMethod()
    {
        var countTask = await CalcSomething();
        // here I can do other stuff which doesn't rely on the result of `countTask`
        Console.WriteLine("Calculating...");
        // now I NEED the result of the task therefore `countTask.Result` will block
        // until the task returns
        Console.WriteLine(String.Format("Result = {0}", countTask.Result));
    }
