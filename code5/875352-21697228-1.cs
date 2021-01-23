    public class MyErrorHandler : IErrorHandler
    {
        // ...
        private static readonly Dictionary<Type, TraceLevel> _exceptionTraceLevelMappings;
        
        static MyErrorHandler()
        {
            _exceptionTraceLevelMappings = new Dictionary<Type, TraceLevel>();
            _exceptionTraceLevelMappings.Add(typeof(ApplicationException), TraceLevel.Information);
            _exceptionTraceLevelMappings.Add(typeof(ArgumentException), TraceLevel.Warning);
        }
    
        private static TraceLevel GetLevelByExceptionType(Type exType)
        {
            // You might want to add a more sophisticated approach here (e.g. for base classes)
            if (_exceptionTraceLevelMappings.ContainsKey(exType))
                return _exceptionTraceLevelMappings[exType];
            return TraceLevel.Error;
        }
        // ...
    }
