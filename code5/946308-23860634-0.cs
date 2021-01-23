    public class TimeTextBox : TextBox
    {
        public TimeTextBox()
        {
            this.KeyPress += TimeTextBox_KeyPress;
        }
        public DateTime timeValue = new DateTime();
        private void TimeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if(char.IsDigit(e.KeyChar))
            {
                Text += e.KeyChar;
                SelectionStart = Text.Length;
            }
            else
            {
                MessageBox.Show("Wrong input");
                return;
            }
            FixText();
            if(Text.Length > 3  && !DateTime.TryParse(Text, out timeValue))
            {
                MessageBox.Show("Wrong input");
                Text = Text.Remove(Text.Length - 1);
                FixText();
                timeValue = DateTime.Parse(Text);
            }
        }
        private void FixText()
        {
            Text = Text.Replace(":", "");
            for(int i = Text.Length - 3; i > -1; i -= 2)
            {
                Text = Text.Insert(i + 1, ":");
                SelectionStart = Text.Length;
            }
        }
    }
