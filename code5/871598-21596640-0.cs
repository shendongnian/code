    class Foo : Form
    {
        private int nextButtonToShow = 0;
        private Timer timer;
        private Button[] buttons;
        internal Foo()
        {
            timer = new Timer();
            timer.Tick += ShowNextButton;
            timer.Interval = 1000;
            timer.Enabled = true;
        }
        private void ShowNextButton(object sender, EventArgs e)
        {
            // TODO: Set location etc
            Button button = new Button { Text = nextButtonToShow.ToString() };
            button.Click += ...;
            buttons[i] = button;
            Controls.Add(button);
            nextButtonToShow++;
            if (nextButtonToShow == buttons.Length)
            {
                timer.Enabled = false;
            }
        }
    }
    
