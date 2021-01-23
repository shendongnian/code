    class Helper {
        public static int MakeParam(int myParam) {
          return MakeParam(use_your_default_value_as_specified);
        }
        public static int MakeParam(int myParam, int default) {
          return myParam < 20 ? myParam : default;
        }
    }
