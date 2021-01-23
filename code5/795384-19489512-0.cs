        static void Main()
        {
            IEnumerator<int> typed = GetInts();
            typed.MoveNext();
            Console.WriteLine(typed.MoveNext());
            int i = typed.Current;
            IEnumerator untyped = GetInts();
            untyped.MoveNext();
            Console.WriteLine(untyped.MoveNext());
            object o = untyped.Current;
        }
        static IEnumerator<int> GetInts()
        {
            yield return 4;
            yield break;
        }
