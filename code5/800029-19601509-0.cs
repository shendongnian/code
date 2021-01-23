    public partial class Form1 : Form
    {
        public int YPos { get; set; }
        List<string> Labels = new List<string>();
        List<Label> LabelControls = new List<Label>();
        List<TextBox> TextBoxControls = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            AddRow("medium string", "medium");
            AddRow("This is a longer string", "long");
            AddRow("l", "little");
            Arrange();
        }
        void AddRow(string label, string value)
        {
            Labels.Add(label);
            var LabelID = new Label();
            LabelID.AutoSize = true; // make sure to enable AutoSize
            LabelID.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            LabelID.Name = "label" + Labels.Count;
            LabelID.Text = label;
            LabelID.Location = new System.Drawing.Point(12, YPos);
            this.Controls.Add(LabelID);
            panel1.Controls.Add(LabelID);
            LabelControls.Add(LabelID);
            var BoxID = new TextBox();
            BoxID.Font = new System.Drawing.Font("Arial", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BoxID.Name = "textbox" + Labels.Count;
            BoxID.Text = value;
            BoxID.Location = new System.Drawing.Point(12, YPos);
            BoxID.Size = new System.Drawing.Size(240, 19);
            this.Controls.Add(BoxID);
            panel1.Controls.Add(BoxID);
            TextBoxControls.Add(BoxID);
            // both controls have the same Y location
            // and initially will have the same X location
            YPos += 25;
        }
        void Arrange()
        {
            // determine the widest label sized by the AutoSize 
            int maxLabelX = 0;
            for (int i = 0; i < Labels.Count; i++)
            {
                maxLabelX = Math.Max(maxLabelX, LabelControls[i].Location.X + LabelControls[i].Size.Width);
            }
            // move all the text boxes a little to the right of the widest label
            for (int i = 0; i < Labels.Count; i++)
            {
                TextBoxControls[i].Location = new Point(maxLabelX + 10, TextBoxControls[i].Location.Y);
            }
        }
    }
