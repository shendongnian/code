    public class QuestionNode : TreeNode
    {
        private readonly string question;
        public QuestionNode(string question)
        {
            this.question = question;
            this.Text = string.Format("Question: {0}", question);
        }
    }
