    public class Jane : ICook
    {
        public IMeal Cook()
        {
            Task<Pasta> pastaTask = PastaCookingOperations.MakePastaAsync();
            Task<Sauce> sauceTask = PastaCookingOperations.MakeSauceAsync();
            return PastaCookingOperations.Combine(pastaTask.Result, sauceTask.Result);
        }
    }
