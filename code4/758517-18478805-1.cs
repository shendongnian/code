    public partial class DetachedForm : Form
    {
        public event EventHandler<SelectionMadeEventArgs> SelectionMade;
        public DetachedForm()
        {
            InitializeComponent();
        }
        private void OnSelectionMade(SelectionMadeEventArgs e)
        {
            EventHandler<SelectionMadeEventArgs> handler = SelectionMade;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void TriggerButton_Click(object sender, EventArgs e)
        {
            if (OptionComboBox.SelectedItem != null)
            {
                SelectionMadeEventArgs args = new SelectionMadeEventArgs(OptionComboBox.SelectedItem.ToString());
                OnSelectionMade(args);
            }
        }
    }
    public class SelectionMadeEventArgs : EventArgs
    {
        public SelectionMadeEventArgs(String actualSelection)
        {
            ActualSelection = actualSelection;
        }
        public String ActualSelection { get; set; }
    }
