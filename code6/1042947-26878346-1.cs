    public partial class ReportInfo : Form
    {
        public ReportInfo(String System, String Manager, String Function, String Speed)
        {
            InitializeComponent();
    
            systemNameTextBox.Text = System;
            contactName1TextBox.Text = Manager;
            functionNameTextBox.Text = Function;
            durationMSTextBox.Text = Speed;
        }
    }
