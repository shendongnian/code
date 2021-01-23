        public interface IMyUi
        {
            // put whatever functions you need to access from LibA
            string GetData();
        }
        public static class MyUiProvider
        {
            public static IMyUi MyUi;
        }
