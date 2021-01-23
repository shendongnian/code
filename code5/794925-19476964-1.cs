    public static ObjRemoverExtension {
        public static void DeleteObj<T>(this T obj) where T: new()
        {
            obj = null;
        }
    }
