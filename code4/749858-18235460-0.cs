    var parent = tf.StartNew(() =>
    
                            Parallel.ForEach(QuestionsLangConstants.questionLangs.Values, (i, state) =>
                            {
                                try
                                {
                                    qrepo.UploadQuestions(QWorkBook.Worksheets[i.QSheet], QWorkBook.Worksheets[i.QTranslationSheet], i, prog);
    
                                }
                               catch (Exception ex)
                               {
    
                                  context.Dispose();
                                    state.Break();
                                 //make sure the execution fails
                                 throw;
                                }
                            }));
    
    var finalTast = parent.ContinueWith(i =>
                {
                    if (context != null)
                    {
                        DialogResult result = MessageBox.Show("Do You Want to Commit the Questions?", "Save to DB", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
    
                        if (result.Equals(DialogResult.OK))
                        {
                           //Do Stuff here
                        }
                        else
                        {
                            return;
                        }
                    }
            }, TaskContinuationOptions.NotOnFaulted);
