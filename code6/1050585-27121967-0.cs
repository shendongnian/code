        double box1 = double.Parse(Number1TextBox.Text);
        double box2 = double.Parse(Number2TextBox.Text);
        double box3 = double.Parse(Number3TextBox.Text);
        double answer = box1 * box2 * box3;
        AnswerLabel.Text = "The answer is"+ answer.ToString();
