        private void backgroundWorkerGenNum_DoWork(object sender, DoWorkEventArgs e)
        {
            int numLimit = 50000000;
            var array = Enumerable.Range(1, numLimit).ToArray();
            array.Shuffle();
            int i = 0;
            using(StreamWriter file = new StreamWriter("numbers.txt"))
               foreach (int element in array)
               {
                   file.WriteLine(element);
                   ++i;
                   backgroundWorkerGenNum.ReportProgress(i);
               }
        }
