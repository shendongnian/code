    public static class IEnumeratorExtensions
    {
        public static Instruction NextInstruction(this IEnumerator<Instruction> @this)
        {
            if (@this.MoveNext())
            {
                return @this.Current;
            }
            return null; // or throw, or whatever you like
        }
    }
