    public class GradingSystem
    {
        private readonly Random _rnd = new Random();
        public event Action<ExamData, ExamResult> ExceptionalResultFound;
        public event Action<ExamData, ExamResult> ResultFound;
        protected virtual void RaiseResultFound(ExamData arg1, ExamResult arg2)
        {
            Action<ExamData, ExamResult> handler = ResultFound;
            if (handler != null) 
                handler(arg1, arg2);
        }
        protected virtual void RaiseExceptionalResultFound(ExamData arg1, ExamResult arg2)
        {
            var handler = ExceptionalResultFound;
            if (handler != null)
                handler(arg1, arg2);
        }
        //long running task  
        public void EvaluateAsync(ExamData data)
        {
            //some evaluation logic
            var result = new ExamResult {Grade = 100 - _rnd.Next(100)};
            if (result.Grade > 95)
                RaiseExceptionalResultFound(data, result);
            RaiseResultFound(data, result);
        }
    }
    public class ExamResult
    {
        public decimal Grade { get; set; }
    }
    public class ExamData
    {
        public string StudentName { get; set; }
    }
