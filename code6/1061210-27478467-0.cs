    public async Task Load(){
        await new TaskFactory().StartNew(() =>
        {
            Task task1 = GetAsync(1);
            Task task2 = GetAsync(2);
            Task task3 = GetAsync(3);
            var data1 = await task1; // <--Freezes here when called from GetSomethingElse()
            var data2 = await task2;
            var data3 = await task3;
            ..process data..
        });
    }
