    internal class WizardStepService : IDisposable
    {
        private IEnumerator<Question> _questions;
        public WizardStepService(Exam exam)
        {
            _questions = exam.Questions.GetEnumerator();
        }
        public void Dispose()
        {
            if (_questions != null) _questions.Dispose();
        }
        public Question GetNextQuestion()
        {
            if (_questions != null)
            {
                if (_questions.MoveNext())
                {
                    return _questions.Current;
                }
                Dispose(); // no more questions!
            }        
    
            //should have a return type hence this or else not required.
            return null;
        }
    }
