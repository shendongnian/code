    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    
            private System.Windows.Forms.TextBox[] textBoxes = new System.Windows.Forms.TextBox[5];
    
            public Form1()
            {
                InitializeComponent();
    
                for (int i = 0; i < textBoxes.Length; i++)
                {
                    textBoxes[i] = new System.Windows.Forms.TextBox();
                    this.textBoxes[i].Location = new System.Drawing.Point(90, 50 + i * 20);
                    this.textBoxes[i].Name = "textBox" + i;
                    this.textBoxes[i].Size = new System.Drawing.Size(100, 20);
                    this.textBoxes[i].TabIndex = i + 1;
                    this.textBoxes[i].Parent = this;
                    this.Controls.Add(textBoxes[i]);
                }
            }
        }
    }
