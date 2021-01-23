        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void TestBox(MyBox box)
        {
            if (box.Value.GetType() == typeof(double))
                TakeDouble((double)box.Value);
            else if (box.Value.GetType() == typeof(MyObject))
                TakeObject((MyObject)box.Value);
        }
