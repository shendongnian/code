    var client = new ClientOutput();
    var executionList = new List<Action>()
        {
            () => { Debug.WriteLine("whatyousay"); Thread.Sleep(500); },
            () => { Debug.WriteLine("allyourbase"); Thread.Sleep(500); },
        };
    foreach (Action action in executionList)
        await client.Execute(action);
    Debug.WriteLine("arebelongtous");
