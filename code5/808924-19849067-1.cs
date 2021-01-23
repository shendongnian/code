        public partial class Form1 : Form
        {
            Dictionary<int, Quiz> questions;
            Random rand = new Random();
            int position = 0;
            int correct = 0;
            int incorrect = 0;
    
            public Form1()
            {
                InitializeComponent();
                btnanswer.Enabled = false;
                questions = new Dictionary<int, Quiz>()
                {
                    {0,new Quiz("What year did President Eisenhower become relieved of Presidency?","1982")},
                    {1,new Quiz("What U.S. base was bombed forcing the United States to become involved in World War II","PEARL HARBOR")},
                    {2,new Quiz( "What was the profession of Abraham Lincolns' assassin?","ACTOR")},
                };
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                lblquestion.Text = ("Welcome! In this category of Trivia you will be quizzed on questions about movies, actors/actresses, television shows and more! Press 'Start Trivia' when you are ready");
                txtanswer.Enabled = false;
            }
       
            private void KeepScore()
            {
                lblcorrect.Text = "Correct: " + correct;
                lblincorrect.Text = "Incorrect: " + incorrect;
            }
            
            private void txtanswer_TextChanged(object sender, EventArgs e)
            {
                //textbox always return empty string but i placed this here
                //so no need to create a variable and let you know
                //about other options....
                if (!string.IsNullOrEmpty(txtanswer.Text))
                {
                    btnanswer.Enabled = true;
                }
                else
                {
                    btnanswer.Enabled = false;
                }
            }
    
            private void ResetPrompt()
            {
                lblquestion.Text = "";
                txtanswer.Text = "";
            }
    
            private void AnalyzeQuestion()
            {
                if (string.Equals(txtanswer.Text, questions[position].Answer, StringComparison.CurrentCultureIgnoreCase))
                {
                    MessageBox.Show("You got this one right!", "Correct!");
                    correct += 1;
                }
                else
                {
                    MessageBox.Show("You got this one wrong! the correct answer was " + questions[position].Answer);
                    incorrect += 1;
                }
            }
    
            private void btnanswer_Click(object sender, EventArgs e)
            {
                AnalyzeQuestion();
                KeepScore();
                ResetPrompt();
                
                if (questions.Values.All(b => b.IsAnswered == true))
                {
                    ResetAll();
                    return;
                }
                GetQuestion();
            }
    
            private void btnstart_Click(object sender, EventArgs e)
            {
                btnstart.Enabled = false;
                GetQuestion();
            }
    
            private void GetQuestion()
            {
                position = rand.Next(0, 3);
                if (questions[position].IsAnswered != true)
                {
                    questions[position].IsAnswered = true;
                    lblquestion.BackColor = Color.Red;
                    lblquestion.Text = questions[position].Question;
                    txtanswer.Enabled = true;
                }
                else
                {
                    while (questions[position].IsAnswered == true)
                    {
                        position = rand.Next(0, 3);
                    }
                    questions[position].IsAnswered = true;
                    lblquestion.BackColor = Color.Red;
                    lblquestion.Text = questions[position].Question;
                    txtanswer.Enabled = true;
                }
            }
    
            private void ResetAll()
            {
                txtanswer.Enabled = false;
                btnanswer.Enabled = false;
                position = 0;
                foreach (var item in questions.Values)
                {
                    item.IsAnswered = false;
                }
                lblquestion.Text = "Game Over!!!...Please Press Start to Play Again.";
                btnstart.Enabled = true;
            }
        }
