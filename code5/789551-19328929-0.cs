    public static class MyModuleWrapper
    {
        // it would be easier to create a delegate once and reuse it
        private static Lazy<Func<int, int, int>> addXAndY = new Lazy<Func<int, int, int>>(() =>
            (Func<int, int, int>)Delegate.CreateDelegate(typeof(Func<int, int, int>), typeof(MyModule).GetMethod("add x and y"))
        );
        public static int AddXAndY(int x, int y)
        {
            return addXAndY.Value(x, y);
        }
        // pass other methods through.
        public static int OtherMethod(int x, int y)
        {
            return MyModule.OtherMethod(x, y);
        }
    }
