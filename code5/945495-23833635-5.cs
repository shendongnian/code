    public class Servy : ICook
    {
        public IMeal Cook()
        {
            var bobsWork = Task.Run(() => PastaCookingOperations.MakePasta());
            var janesWork = Task.Run(() => PastaCookingOperations.MakeSauce());
            return PastaCookingOperations.Combine(bobsWork.Result, janesWork.Result);
        }
    }
