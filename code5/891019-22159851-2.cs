    public static class TestViewModelExtensions
    {
        public static void ExecuteOpenCommand(this TestViewModel vm)
        {
            // do stuff
        }
        public static bool CanOpenCommandExecute(this TestViewModel vm)
        {
            return vm.TestBoolean;
        }
    }
