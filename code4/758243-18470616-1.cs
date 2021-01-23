    public partial class LeanBodyMass : PhoneApplicationPage
    {
        private decimal bodyWeight;
        private decimal bodyFatPercentage;
        public LeanBodyMass()
        {
            InitializeComponent();
        }
        private decimal GetBodyFatAmount()
        {
            return bodyFatPercentage / 100m * bodyWeight;
        }
        private void ConvertInput()
        {
            bodyWeight = Convert.Decimal(bodyweightTextBox.Text);
            bodyFatPercentage = Convert.Decimal(bodyFatTextBox.Text);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ConvertInput();
            this.GetBodyFatAmount();
            decimal leanBodyMass = bodyWeight - bodyFatAmount;
            if (kilogramsRadioButton.IsChecked ==true)
            {
                resultTextBox.Text = string.Format("{0} Kilos", leanBodyMass);
            }
            else if (poundsRadioButton.IsChecked == true)
            {
                resultTextBox.Text = string.Format("{0} Lbs", leanBodyMass);
            }
        }
    }
