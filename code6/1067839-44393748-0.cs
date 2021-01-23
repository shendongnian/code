    enum ExistState { exist, notExist, inaccessible };
    
    void Check(string name) {
        DirectoryInfo di = new DirectoryInfo(name);
        ExistState state = ExistState.exist;
        if (!di.Exists) {
            try {
                if ((int)di.Attributes == -1) {
                    state = ExistState.notExist;
                }
            } catch (UnauthorizedAccessException) {
                state = ExistState.inaccessible;
            }
        }
        Console.WriteLine("{0} {1}", name, state);
    }
