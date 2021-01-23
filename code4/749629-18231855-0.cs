    class Program2
    {
        static void Main(string[] args)
        {
            Exam exam1 = new Exam()
            {
                Questions = new List<Question>
                                                 {
                                                     new Question("question1"),
                                                     new Question("question2"),
                                                     new Question("question3")
                                                 }
            };
            var wizardStepService = new WizardStepService(exam1);
            
            foreach (var question in wizardStepService.GetQuestions())
            {
                Console.WriteLine(question.Content);
                Console.ReadLine();
            }
        }
    }
    public class Question
    {
        private readonly string _text;
        public Question(string text)
        {
            _text = text;
        }
        public string Content
        {
            get
            {
                return _text;
            }
        }
    }
    internal class Exam
    {
        public IEnumerable<Question> Questions
        {
            get;
            set;
        }
    }
    internal class WizardStepService
    {
        private readonly Exam _exam;
        public WizardStepService(Exam exam)
        {
            _exam = exam;
        }
        public IEnumerable<Question> GetQuestions()
        {
            foreach (var question in _exam.Questions)
            {
                //This always returns the first item.How do I navigate to next 
                //item when GetNextQuestion is called the second time?
                yield return question;
            }
            //should have a return type hence this or else not required.
            //return null;
        }
    }
