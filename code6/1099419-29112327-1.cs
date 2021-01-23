    public class SurveyTextBox : RadTextBox, ISurveyControl
    {
        public int QuestionID {get; set;}
        public object Value
        {
            get { return Text; }
            set { Text = value.ToString(); }
        }
    }
    public class SurveyComboBox : RadComboBox, ISurveyControl
    {
        public int QuestionID {get; set;}
        public object Value
        {
            get { return SelectedValue; }
            set { SelectedValue = value.ToString(); }
        }
    }
