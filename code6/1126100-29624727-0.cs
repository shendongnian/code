            private void RegenerateSubmissionPdf(int submissionId)
            {
                var submissionPath = PublisherConfigurationManager.SubmissionPath + submissionId;
    
                var tasks = new List<Task>
                {
                    HttpContext.Current.GeneratePdfTask(submissionPath, submissionId, PublisherConst.SubmissionPdfName,
                        _objSubmission.SaveSubmissionPdf)
                };
                tasks.ForEach(t => t.ContinueWith(ExceptionHandler, TaskContinuationOptions.OnlyOnFaulted));
                tasks.SendEmailTasks(u => SendRegenerateSubmissionPdfEmail(submissionId, u));
            }
            private void ExceptionHandler(Task task)
            {
                // Handle exception
            }
