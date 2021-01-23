    class DiceRoller
    {
        private Random _random = new Random();
        private Form1 _mainForm;
        public DiceRoller(Form1 f)
        {
            _mainForm = f;
        }
        public void RollDice()
        {
            _mainForm.DicerollLabel.Text = "Hello World!";
        }
    }
