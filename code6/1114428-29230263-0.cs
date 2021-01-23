    public class MathPuzzle
    {
    
        public string Question { get; set; }
    
        public double Answer { get; set; }
    
        public void PrepareQuestion()
        {
            Random random = new Random();
            int num1 = random.Next(0, 100);
            char[] operators = { '+', '-', '*', '/' };
            char op = operators[random.Next(operators.Length)];
            int num2 = random.Next(0, 100);
    
            switch (op)
            {
                case '+':
                    Answer = num1 + num2;
                    break;
    
                case '-':
                    Answer = num1 - num2;
                    break;
                case '*':
                    Answer = num1 * num2;
                    break;
                case '/':
                    Answer = Math.Round((double)num1 / (double)num2, 2);
                    break;
            }
    
            Question = string.Format("{0} {1} {2}", num1, op, num2);
        }
    
        public bool CheckTheAnswer(double userProvidedAnswer)
        {
            return userProvidedAnswer == Answer;
        }
    }
