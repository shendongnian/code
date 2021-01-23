    using System.Windows.Forms;
    public class Yourclass{
        private Label UpdateLabel;
        public Yourclass (Label yourLabel)
        {
            this.UpdateLabel = yourlabel;
        }
        private void action()
        {
            //here is your update of the label
            UpdateLabel.Text = "Your text";
        }
    }
