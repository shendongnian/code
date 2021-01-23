    public async void SendBuffer(DataOutputStream clientOuput)
    {
        var executionList = new List<Action>()
            {
                () => { Debug.WriteLine("whatyousay"); Thread.Sleep(1500); },
                () => { Debug.WriteLine("allyourbase"); Thread.Sleep(1500); },
            };
    
        clientOuput.WriteInt(1);
        foreach (Action action in executionList)
            await clientOuput.Execute(action);
    
        Debug.WriteLine("arebelongtous");
    }
