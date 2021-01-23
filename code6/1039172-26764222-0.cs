    [StructLayout(LayoutKind.Explicit)]
    public struct _UnionLongAnd2Ints
    {
        [FieldOffset(0)] public int LowerWord;
        [FieldOffset(4)] public int UpperWord;
        [FieldOffset(0)] public long Value;
    }
    public struct LongTwoIntsUnionAndSomethingElse<T>
    {
      UnionLongAnd2Ints UnionPart;
      T OtherPart;
    }
