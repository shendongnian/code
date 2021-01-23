    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            Button[] myButtons = new Button[10];
            private void Form1_Load(object sender, EventArgs e)
            {
                for(int i = 0; i < myButtons.Length; i++)
                {
                    int index = i;
                    this.myButtons[i] = new Button();
                    this.myButtons[i].Location = new System.Drawing.Point(((i + 1) * 70), 100 + ((i + 10) * 5));
                    this.myButtons[i].Name = "button" + (index + 1);
                    this.myButtons[i].Size = new System.Drawing.Size(70, 23);
                    this.myButtons[i].TabIndex = i;
                    this.myButtons[i].Text = "button" + (index + 1);
                    this.myButtons[i].UseVisualStyleBackColor = true;
                    this.myButtons[i].Visible = true;
                    myButtons[i].Click += (sender1, ex) => this.Display(index+1);
                    this.Controls.Add(myButtons[i]);
                }
            }
            public void Display(int i)
            {
                MessageBox.Show("Button No " + i);
            }
        }
    }
