    public delegate void EventHandler();
    
    public partial class Form1 : Form
    {
        public event EventHandler QuizGradesChanged;
    
        public Form1()
        {
            InitializeComponent();
            QuizGradesChanged += addArrayElementsToListbox;
        }
        StudentQuizGrade [] quizGrades = new StudentQuizGrade [0];
    
        private void button1_Click(object sender, EventArgs e)
        {
            addToArray();
            clearAddInputs();
        }
        private void clearAddInputs()
        {
            txtStudentName.Clear();
            txtStudentNumber.Clear();
            txtQuizGrade.Clear();
        }
        public void addArrayElementsToListbox()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Student Name \t Student Number \t Quiz Grade");
            foreach (StudentQuizGrade quizGrade in quizGrades)
            {
                listBox1.Items.Add(quizGrade.StudentName + "\t" + quizGrade.StudentNumber + "\t\t" + quizGrade.QuizGrade);
            }
        }
        public void addToArray()
        {
            Array.Resize(ref quizGrades, quizGrades.Count + 1);
            quizGrade[quizGrades.Count- 1] = new StudentQuizGrade() {
                QuizGrade = Convert.ToInt32(txtQuizGrade.Text);
                StudentName = txtStudentName.Text;
                StudentNumber = txtStudentNumber.Text;
            }
            QuizGradesChanged();
        }
    
        private void ClearButton_Click(object sender, EventArgs e)
        {
            clearAddInputs();
            Array.Clear(quizGrades, 0,quizGrades.Length);
            QuizGradesChanged();
        }    
    }
