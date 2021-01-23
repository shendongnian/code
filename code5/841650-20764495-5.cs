    var input = "I have a listbox in my windows form application that shows quite long texts. Since texts are so long, user have to use the horizontal slider for check the rest of text.\nSo, I want to limit listbox character per line. For every 50 char it should go to next row, so user won't have to use glider.";
    input = String.Join(" ", Enumerable.Repeat(input, 100));
    var t1 = Measure(10, () =>
    {
        var lines = input.SplitByLength_LB(50).ToArray();
    });
    var t2 = Measure(10, ()=>
    {
        var lines = input.SplitByLength_tinstaafl(50).ToArray();
    });
---
    long Measure(int n,Action action)
    {
        action(); //JIT???
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < n; i++)
        {
            action();
        }
        return sw.ElapsedMilliseconds;
    }
