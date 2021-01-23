    class RandomButtonForm : Form
    {
        private Random rng;
        private List<Button> buttons;
        public RandomButtonForm()
        {
            this.rng = new Random();
            this.buttons = new List<Button>();
            this.AddButton(10, 10, "Button 1");
            this.AddButton(110, 10, "Button 2");
            this.AddButton(210, 10, "Button 3");
        }
        public AddButton(int x, int y, string text)
        {
            Button button = new Button();
            button.Visible = false;
            button.X = x;
            button.Y = y;
            button.Text = text;
            this.buttons.Add(button);
            this.Controls.Add(button);
        }
        private void A_Click(object sender, EventArgs e)
        {
            int r = this.rng.Next(this.buttons.Count);
            for (int b = 0; b < this.buttons.Count; b++)
            {
                this.buttons[b].Visible = (b == r);
            }
        }
    }
