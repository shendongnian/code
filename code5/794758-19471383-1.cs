    public class QuestionNode : TreeNode
    {
        private string question;
        public string Question
        {
            get { return question; } 
            set
            {
                this.question = value;
                this.Text = string.Format("Question: {0}", question);
            }
        }
    }
