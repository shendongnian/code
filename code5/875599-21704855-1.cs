            var tasks = new List<Task>();
            foreach (var acc in Accounts)
            {
                tasks.Add(() =>
                {
                    acc.WebProxy = null;
                    Debug.WriteLine("Connecting to {0}.", new object[] { acc.Username });
                    return acc.ConnectToIrc();
                });
            }
            await Task.WhenAll(tasks);
