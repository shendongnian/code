     var parent = tf.StartNew(() =>
        Parallel.ForEach(QuestionsLangConstants.questionLangs.Values, (i, state) =>
              {
                 try
                   {
                     qrepo.UploadQuestions(QWorkBook.Worksheets[i.QSheet],
                     QWorkBook.Worksheets[i.QTranslationSheet], i, prog);
                   }
                 catch (Exception ex)
                   {
                                   
                     context.Dispose();
                     state.Break();
                    //make sure the execution fails  
                    throw; //<-- This line was added to stop the continuation task.
                   }
              }));
    
    var finalTast = parent.ContinueWith(i =>
                {
                   //...
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
