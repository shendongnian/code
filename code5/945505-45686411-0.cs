    public class DuplicateMarkSwallower : IFailuresPreprocessor
    {
        public FailureProcessingResult PreprocessFailures(FailuresAccessor a)
        {
            var failures = a.GetFailureMessages();
            foreach (var f in failures)
            {
                var id = f.GetFailureDefinitionId();
                if (BuiltInFailures.GeneralFailures.DuplicateValue == id)
                {
                    a.DeleteWarning(f);
                }
            }
            return FailureProcessingResult.Continue;
        }
    }
