    public class SomeOtherClass
    {
        public static void DoWork(string filepath, IProgress<int> progress)
        {
            int currentProgress = 0;
            foreach (var line in File.ReadLines(filepath))
            {
                DoSomethingWithLine();
                currentProgress++;
                progress.Report(currentProgress);
            }
        }
    }
