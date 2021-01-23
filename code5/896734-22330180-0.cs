    interface IBuildGenerically<T1, T2, T3, T4>
    {
        T Build(T1 param1, T2 param2, T3 param3, T4 param4);
    }
    public class GenericTest<T : MyBuilder> where T: IBuildGenerically<int, string, int, bool>
