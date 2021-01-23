        private List<InfoTextBox> activeTextBoxes = new List<InfoTextBox>();
        public Form1()
        {         
            for (int i = 0; i < Calculation.Num; i++)
            {
                TextBox txtRun = new TextBox();
                txtRun.Name = "txtBox" + i;
                txtRun.Location = new System.Drawing.Point(35, 50 + (20 * i) * 2);
                txtRun.Size = new System.Drawing.Size(75, 25);
                this.Controls.Add(txtRun);
                InfoTextBox iBox = new InfoTextBox();
                iBox.textbox = txtRun;
                activeTextBoxes.Add(iBox);
            }
        }
        public class InfoTextBox
    {
        private double _textboxValue;
        public TextBox textbox { get; set; }
        public double TextBoxValue { get { return _textboxValue; } set { _textboxValue = setValue(value); } }
        private double setValue(double invalue)
        {
            return invalue / 100;
        }
    }
