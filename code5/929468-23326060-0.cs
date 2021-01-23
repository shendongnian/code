    class QuestionBank
    {
        private List<QuestionUnit> m_Questions = new List<QuestionUnit>();
        public bool ReadQuestionFile()
        {
            bool success = true;
            FileInfo theSourceFile = new FileInfo("Questions.txt");
            string line;
            try
            {
                StreamReader thereader = theSourceFile.OpenText();
                line = thereader.ReadLine();
                while (line != null)
                {
                    QuestionUnit ques = new QuestionUnit();
                    ques.Question = line;
                    line = thereader.ReadLine();
                    ques.Answer = line;
                    line = thereader.ReadLine();
                    ques.CorrectAnswer = line;
                    line = thereader.ReadLine();
                    ques.Explanation = line;
                    line = thereader.ReadLine();
                    m_Questions.Add(ques);
                }
            }
            catch
            {
                success = false;
            }
            return success;
        }
    }
