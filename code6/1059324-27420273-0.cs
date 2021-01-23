    public static class AssertEx
    {
        public static void AllAreEqual<T>(params T[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                Assert.AreEqual(items[0], items[i]);
            }
        }
    }
