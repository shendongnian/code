     string[] possible_answers = { "A", "B", "C", "D" };
        private void button2_Click(object sender, EventArgs e)
        {
            ResetLabels();
        }
        private void ResetLabels()
        {
            for (int i = 0; i < this.labelContainer.Controls.Count - 1; i++)
            {
                this.labelContainer.Controls[i].Dispose();
            }
            this.labelContainer.Controls.Clear();
            for (int i = possible_answers.Count() - 1; i >= 0; i--)
            {
                Label l = new Label();
                l.Text = possible_answers[i];
                l.Dock = DockStyle.Top;
                this.labelContainer.Controls.Add(l);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            RemoveWrongLabels(3, 2);
        }
        private void RemoveWrongLabels(int RightAnswer, int ItemsToDisplay)
        {
            Random rand = new Random();
            List<int> AnswersToHide = new List<int>();
            while (AnswersToHide.Count < labelContainer.Controls.Count - ItemsToDisplay)
            {
                int indexToHide = rand.Next(0, labelContainer.Controls.Count);
                if (!AnswersToHide.Contains(indexToHide) && labelContainer.Controls[indexToHide].Text != possible_answers[RightAnswer])
                {
                    AnswersToHide.Add(indexToHide);
                }
            }
            foreach (var item in AnswersToHide)
            {
                this.labelContainer.Controls[item].Visible = false;
            }
        }
