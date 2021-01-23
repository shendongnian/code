    public class Bob : ICook
    {
        public IMeal Cook()
        {
            Pasta pasta = PastaCookingOperations.MakePasta();
            Sauce sauce = PastaCookingOperations.MakeSauce();
            return PastaCookingOperations.Combine(pasta, sauce);
        }
    }
