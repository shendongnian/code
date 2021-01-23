    public Form1()
        {
            InitializeComponent();
            int topMod = 0;
            for (int i = 0; i < 5; i++)
            {
                MakeButton(i,topMod);
                topMod += 20;
            }
        }
        public void MakeButton(int index, int margin)
        {
            Button currentButton = new Button();
            currentButton.Text = "Note" + index;
            currentButton.Top += margin;
            currentButton.Click += OnButtonClick;
            panel1.Controls.Add(currentButton);
        }
        public void OnButtonClick(object sender, EventArgs e)
        {
            //checkIfThisNoteWasCorrect();
            //highLightThisButton();
            //setHighLightOffForAllOtherButtons(); 
            MessageBox.Show("My Action was activated!");
        }
