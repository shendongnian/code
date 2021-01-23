    public class StuckingProgressObserver : IProgressObserver
    {
        private const double stucksAfter = 0.95;
        private readonly IProgressObserver wrapee;
        public StuckingProgressObserver(IProgressObserver wrapee)
        {
            this.wrapee = wrapee;
        }
        public void NotifyProgress(double done)
        {
            if (done < stucksAfter)
            {
                wrapee.NotifyProgress(done);
            }
        }
    }
