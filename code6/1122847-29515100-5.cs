    public class MyClass
    {
        public IEnumerable<IEither<int, string>> Divide(int left, IEnumerable<int> right)
        {
            foreach (var num in right)
            {
                if (num == 0)
                {
                    yield return Either.Right<int, string>("cannot divide by zero");
                }
                yield return Either.Left<int, string>(left/num);
            }
        }
    }
