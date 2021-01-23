    private void RegenerateSubmissionPdf(int submissionId)
    {
        var submissionPath = PublisherConfigurationManager.SubmissionPath + submissionId;
    
        var task = HttpContext.Current.GeneratePdfTask(submissionPath, submissionId, PublisherConst.SubmissionPdfName,
                _objSubmission.SaveSubmissionPdf);
        task.ContinueWith(t =>  
          SendRegenerateSubmissionPdfEmail(submissionId, task),  
          TaskContinuationOptions.OnlyOnRanToCompletion);
        task.ContinueWith(t =>  
          HandleException(task.Exception),  
          TaskContinuationOptions.OnlyOnFaulted);
        await task;
    }
