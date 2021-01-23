    namespace ClipboardTests
    {
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            private MyCustomTextBox MyTextBox;
            public Form1()
            {
                InitializeComponent();
                MyTextBox = new MyCustomTextBox();
                this.Controls.Add(MyTextBox);
            }
        }
        public class MyCustomTextBox : TextBox
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0x302 && Clipboard.ContainsText())
                {
                    var cbText = Clipboard.GetText(TextDataFormat.Text);
                    // manipulate the text
                    cbText = cbText.Replace("'", "").Replace("\"", "");
                    // 'paste' it into your control.
                    SelectedText = cbText;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }
        }
    }
