    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Button myButton;
            public Form1()
            {
                InitializeComponent();
                myButton = new Button();
                myButton.Location = new System.Drawing.Point(50, 12);
                myButton.Size = new System.Drawing.Size(100, 23);
                myButton.Text = "My Button";
                this.Controls.Add(myButton);
            }
        }
    }
