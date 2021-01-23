    List<int> list = new List<int>();
    object key = new object();
    foreach (int a in b)
        if (a == 1)
        {
            var value = GetValue(a);
            list.Add(value);
            Task.Delay(TimeSpan.FromHours(1))
                .ContinueWith(t => { lock (key)list.Remove(value); });
        }
