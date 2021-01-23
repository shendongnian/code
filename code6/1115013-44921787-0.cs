        public class FloorPreProcessor : IFailuresPreprocessor
    {
        FailureProcessingResult
          IFailuresPreprocessor.PreprocessFailures(
            FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> fmas
              = failuresAccessor.GetFailureMessages();
            if (fmas.Count == 0)
            {
                return FailureProcessingResult.Continue;
            }
            // We already know the transaction name.
            if (fmas.Count != 0)
            {
                foreach (FailureMessageAccessor fma in fmas)
                {
                    // DeleteWarning mimics clicking 'Ok' button.
                    failuresAccessor.DeleteWarning(fma);
                }
                return FailureProcessingResult
                  .ProceedWithCommit;
            }
            return FailureProcessingResult.Continue;
        }
    }
    
