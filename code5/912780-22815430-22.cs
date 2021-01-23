    public partial class ComboBoxControl : UserControl
    {
        public ComboBoxControl(Questions question)
        {
            InitializeComponent();
            label1.Text = question.QuestionText;
            Choice[] choices = question.Choice;
            foreach (var ch in choices)
            {
                comboBox1.Items.Add(ch.AnswerChoice);
  
                if (ch.IsDefault)
                {
                  comboBox1.Text = ch.AnswerChoice;
                }
            }
            // load the saved answer if it exists
            if (question.SelectedChoice != null) {
                comboBox1.Text = string.Empty // not sure if this is needed or not
                comboBox1.SelectedItem = question.SelectedChoice;
            }           
        }
    }
