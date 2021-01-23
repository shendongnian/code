    public class Computations {
        public IEncapsulated<M, IEnumerable<Something>> GetSomethings<M>(IMonadGetSomething<M> monad, int number) {
            var result = monad.Return(Enumerable.Empty<Something>());
            // Our developers might still like writing imperative code
            for (int i = 0; i < number; i++) {
                result = from existing in r1
                         from something in monad.GetSomething()
                         select r1.Concat(new []{something});
            }
            return result.Select(x => x.ToList());
        }
    }
