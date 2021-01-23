    public partial class Form1 : Form
    {
    
        public Form1()
        {
            InitializeComponent();
        }
        StudentQuizGrade [] quizGrades = new StudentQuizGrade [0];
    
        private void button1_Click(object sender, EventArgs e)
        {
            addToArray();
            txtStudentName.Clear();
            txtStudentNumber.Clear();
            txtQuizGrade.Clear();
            addArrayElementsToListbox();
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
        }
        public void txtAverage_TextChanged(object sender, EventArgs e)
            {
            }
    
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            }
    
        private void ClearButton_Click(object sender, EventArgs e)
            {
                listBox1.Items.Clear();
                txtStudentName.Clear();
                txtStudentNumber.Clear();
                txtQuizGrade.Clear();
                Array.Clear(quizGrades, 0,quizGrades.Length);
            }
    
    }
