    partial class QuestionControl : UserControl
    {
        public QuestionControl()
        {
            InitializeComponent();
        }
    
        private Question _question = null;
        public Question Question
        {
            get { return _question; }
            set
            {
                _question = value;
                UpdateUI();
            }
        }
    
        private void UpdateUI()
        {
            mainPanel.Children.Clear();
            if (this.Question != null)
            {
                List<FrameworkElement> controls = new List<FrameworkElement>();
                string[] questionSegments = // some code to split question here
    
                foreach (var qs in questionSegments)
                {
                    controls.Add(new TextBlock() { Text = qs } );
                }
    
                for (int i = 0; i < this.Question.AnswerStrings.Length; i++)
                {
                    string answer = this.Question.AnswerStrings[i];
                    TextBox newTextBox = new TextBox();
                    controls.Insert(i * 2 + 1, newTextBox); // inserting TextBoxes between TextBlocks
                }
    
                foreach (var control in controls)
                {
                    mainPanel.Children.Add(control); // adding all the controls to the wrap panel
                }
            }
        }
    }
