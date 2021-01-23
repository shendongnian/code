    public partial class ComboBoxControl : UserControl
    {
        public ComboBoxControl(Questions question)
        {
            InitializeComponent();
            label1.Text = question.QuestionText;
            Choice[] choice = question.Choice;
            foreach (var ch in choice)
            {
                comboBox1.Items.Add(ch.AnswerChoice);
  
                if (ch.IsDefault)
                {
                  comboBox1.Text = ch.AnswerChoice;
                }
            }
            // load the saved answer if it exists
            if (question.SelectedChoice != null) {
                combobox1.Text = string.Empty // not sure if this is needed or not
                comboBox1.SelectedItem = question.SelectedChoice;
            }
            
            // tie the method to save it to the SelectedIndexChanged event
            combobox1.SelectedIndexChanged += SelectedAnswerChanged;
        }
    }
