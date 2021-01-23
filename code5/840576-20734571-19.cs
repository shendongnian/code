    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private Button myButton;
            public Form1()
            {
                InitializeComponent();
                // Create a new Button
                myButton = new Button();
                // Set the properties of the Button
                myButton.Location = new System.Drawing.Point(50, 12);
                myButton.Size = new System.Drawing.Size(100, 23);
                myButton.Text = "My Button";
                // Add the Button to the form
                this.Controls.Add(myButton);
            }
        }
    }
