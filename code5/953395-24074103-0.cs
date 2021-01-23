    public partial class Form1 : Form
    {
        private List<Button> _buttons = new List<Button>();
        public Form1()
        {
            InitializeComponent();
        }
        private void btnSetBase_Click(object sender, EventArgs e)
        {
            frmDialog frmDialogInput = new frmDialog();
            DialogResult dResult = frmDialogInput.ShowDialog(this);
            if (dResult == DialogResult.OK)
            {
                var digits = frmDialogInput.Base;
                lblOutDigits.Text = digits.ToString();
                CreateBaseButtons(digits);
              }
        }
		private void ClearBaseButtons()
		{
			_buttons.ForEach(b =>
			{
				this.Controls.Remove(b);
				b.Click -= btnNums_Click;
				b.Dispose();
			});
			_buttons.Clear();
		}
        private void CreateBaseButtons(int number)
        {
			this.ClearBaseButtons();
            int x = 34, y = 70;
            for (int j = 0; j < number; j++)
            {
				var button = new Button()
				{
                	Location = new System.Drawing.Point(x, y),
                	Name = "btn" + j,
                	Size = new System.Drawing.Size(45, 23),
                	Text = j.ToString(),
                	UseVisualStyleBackColor = true,
				};
				button.Click += btnNums_Click;
                this.Controls.Add(button);
                _buttons.Add(button);
                x += button.Size.Width;
            }
        }
        private void btnNums_Click(object sender, EventArgs e)
        {
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            lblOutDigits.Text = "  ";
			this.ClearBaseButtons();
        }
    }
