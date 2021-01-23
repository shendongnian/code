    public static class MyApp
    {
        public static void NetTrace(string message, params object[] args)
        {
            Mvx.TaggedTrace("MyAppNet", message, args);
        }
        public static void NetError(string message, params object[] args)
        {
            Mvx.TaggedError("MyAppNet", message, args);
        }
        public static void VmTrace(string message, params object[] args)
        {
            Mvx.TaggedTrace("MyAppVm", message, args);
        }
        public static void VmError(string message, params object[] args)
        {
            Mvx.TaggedError("MyAppVm", message, args);
        }
    }
