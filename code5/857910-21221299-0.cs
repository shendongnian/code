            #region ParallelTasks
            // Perform three tasks in parallel on the source array
            Parallel.Invoke(() =>
                             {
                                 Console.WriteLine("Begin first task...");
                                 GetLongestWord(words);
                             },  // close first Action
                             () =>
                             {
                                 Console.WriteLine("Begin second task...");
                                 GetMostCommonWords(words);
                             }, //close second Action
                             () =>
                             {
                                 Console.WriteLine("Begin third task...");
                                 GetCountForWord(words, "species");
                             } //close third Action
                         ); //close parallel.invoke
            Console.WriteLine("Returned from Parallel.Invoke");
            #endregion
