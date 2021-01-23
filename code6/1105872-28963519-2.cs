    public partial class FormView : Form {
        List<CircleButton> myPanels = new List<CircleButton>(); // local use only in my example
        Point[] arrayPoints_milestones; //not needed anymore
        int index; //not needed anymore
        public FormView() {
            InitializeComponent();
            this.Load += FormView_Load;
        }
        void FormView_Load(object sender, EventArgs args) {
            Point panelOffset = new Point(20, 20);
            for (int i = 0; i < 4; i++) {
                var panel = new CircleButton() {
                    Name = "panel" + i, //Attention! You have hidden the property "Name" in "Control" with a re-declaration in "CircleButton"
                    Tag = i, //not needed anymore, right?
                    Centre = new Point(panelOffset.X + i * 10, panelOffset.Y),
                    Radius = 10,
                    BackColor = Color.Red,
                    Message = "Index: " + Tag.ToString(),
                };
                panel.Click += (s, e) => {
                    panel.Focus();
                };
                panel.PreviewKeyDown += (s, e) => {
                    if(e.KeyCode == Keys.Up) {
                        Point centre = panel.Centre; //copy value
                        centre.Y -= 10;
                        panel.Centre = centre; //assign modified copy
                        Invalidate();
                    }
                    if(e.KeyCode == Keys.Down) {
                        Point centre = panel.Centre; //copy value
                        centre.Y += 10;
                        panel.Centre = centre; //assign modified copy
                        Invalidate();
                    }
                };
                myPanels.Add(panel);
                pictureBox1.Controls.Add(panel);
            }
        }
    }
