    namespace SandboxTest
    {
        public partial class ListBox : Form
        {
            int[] SelectionOrder = new int[50];
            int ClickHistory = 0;
            public ListBox()
            {
                InitializeComponent();
            }
            private void CatchListSelection(object sender, EventArgs e)
            {
                if (ClickHistory == 42)
                {
                    ClickHistory = 0;
                }
                SelectionOrder[ClickHistory] = listBox1.SelectedIndex;
                ClickHistory++;
            }
        }
    }
