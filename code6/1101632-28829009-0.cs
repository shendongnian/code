    public class JobRunner
    {
        public async Task<string> Run()
        {
            ShortMethodIAlwaysWantToWait();
            string jobId = Guid.NewGuid().ToString("N");
            await LongMethodICouldWantToWaitOrNot(jobId);
            return jobId;
        }
        private async Task LongMethodICouldWantToWaitOrNot(string jobId)
        {
            await Task.Delay(5000);
        }
        private async Task ShortMethodIAlwaysWantToWait()
        {
            await Task.Delay(2000);
        }
    }
