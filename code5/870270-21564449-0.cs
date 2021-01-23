    public void SomeBatchRequest(List<Somedata> data) {
        foreach (var d in data) {
            ProcessSingle(d);
        }
    }
    public void ProcessSingle(Somedata d) {
        // do something with d
        ....
    }
