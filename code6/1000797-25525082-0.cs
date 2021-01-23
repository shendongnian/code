    static void Main()
    {
        string s = (new Nullable<int>(123)).GetType().Assembly.FullName;
        string t = (new int?(123)).GetType().Assembly.FullName;
    }
    struct Nullable<T> {public Nullable(T value){} }
