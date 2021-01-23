        // NOT ASYNC ANY MORE: DOES NOT WRAP THE RESULT INTO Task<T2> any more
        public T2 CallAsyncFunc<T1, T2>(T1 a, Func<T1, T2> func)
        {
            return func.Invoke(a);
        }
        public async Task<string> GetString(int value)
        {
            await Task.Run(() => Thread.Sleep(2000));
            return "" + value;
        }
        public async Task MainAsyncEntry()
        {
            string y = await CallAsyncFunc(30, async (x) => await GetString(x));
            string z = await CallAsyncFunc<int, Task<string>>(30, async (x) => await GetString(x));
        }
