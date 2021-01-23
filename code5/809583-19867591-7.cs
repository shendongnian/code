        public Form1()
        {
            InitializeComponent();
            QuizGradesChanged += addArrayElementsToListbox;
            QuizGradesChanged += recalculateAverage
        }
        public void recalculateAverage() {
            if (quizGrades.Count > 0) {
               txtAverage.Text = quizGrades.Select(x => (decimal) x.QuizGrade).Average().ToString();
            } else {
               txtAverage.Text = "No grades to average";
            }
        }
