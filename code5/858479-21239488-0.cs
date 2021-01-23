    static class SomeObjExtensions {
        public static string ToStringWithNull(this object someObj) {
            return someObj == null ? null : someObj.ToString();
        }
    }
