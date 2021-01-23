    public enum TADA
    {
        Foo,
        Bar
    }
    public class TADA_NON_ENUM
    {
    }
    public struct TADA_STRUCT
    {
    }
    public class MyClass
    {
        public void Test()
        {
            TADA[] t = new TADA[1];
            t.WriteCompressed(new MemoryStream()); //just fine
            TADA_NON_ENUM[] tne = new TADA_NON_ENUM[1];
            tne.WriteCompressed(new MemoryStream()); //compile time error
            TADA_STRUCT[] ts = new TADA_STRUCT[1];
            ts.WriteCompressed(new MemoryStream()); //compile time error
        }
    }
    public static class ExtensionClass
    {
        public static void WriteCompressed<T>(this T[] towrite, Stream output) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            //.... Function Code ...
        }
    }
