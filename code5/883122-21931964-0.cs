    private static void Subscribe(Action addHandler)
    {
        var IL = addHandler.Method.GetMethodBody().GetILAsByteArray();
        // Magic here, in which we understand ClassName and EventName
        ???
    }
