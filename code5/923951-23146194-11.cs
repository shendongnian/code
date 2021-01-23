    public class Model
    {
        public void DoWork(ViewModel vm)
        {
            int progressPercentage = 0;
            for (int i = 0; i < 100000; i++)
            {
                vm.OnProgressChanged(this, new ProgressChangedEventArgs(progressPercentage, null));
                if (i%1000 == 0)
                {
                    ++progressPercentage;
                }
            }
        }
    }
