    using System;
    using System.Drawing;
    using System.Windows.Forms;
    namespace boolDecission
    {
        public partial class Form1 : Form
      {
        bool QuestionNeedsSaving = false;
        int x = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            x = x + 1;
            //even number will make QuestionNeedsSaving = false and odd            number will make QuestionNeedsSaving = true. 
            if (x % 2 == 1)
            {
                QuestionNeedsSaving = false;
            }
            else 
            {
                QuestionNeedsSaving = true;
            }
            if (QuestionNeedsSaving == true)
            {
                MessageBox.Show("You have made changes to this question." + "\r\n" + "\r\n" + "Click the Update Question button to " + "\r\n" + "Save changes or the changes will be lost.", "OOPS!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (QuestionNeedsSaving == false)
            {
                GoToNextQuestion();
            }
        }
        public void GoToNextQuestion()
           {
                MessageBox.Show("Next Question");
           }
        }
    }
 
