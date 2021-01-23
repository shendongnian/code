    public partial class mainForm : Form
    {
    Random randonGen = new Random();
    public mainForm()
    {
        InitializeComponent();
    }
    private void mainForm_Load(object sender, EventArgs e)
    {
        populate();
    }
    private void populate()
    {
        Control[] buttonsLeft = createButtons().ToArray();
        Control[] buttonsRight = createButtons().ToArray();
        pRight.Controls.AddRange(buttonsRight);
        pLeft.Controls.AddRange(buttonsLeft);
    }
    private List<Button> createButtons()
    {
        List<Button> buttons = new List<Button>();
        for (int i = 1; i <= 5; i++)
        {
            buttons.Add(
                new Button()
                {
                    Size = new Size(200, 35),
                    Enabled = true,
                    BackColor = GetColor(),
                    ForeColor = GetColor(),
                    UseVisualStyleBackColor = false,
                    Left = 20,
                    Top = (i * 40),
                    Text = String.Concat("Button ", i)
                });
        }
        return buttons;
    }
    private Color GetColor()
    {
        return Color.FromArgb(randonGen.Next(255), randonGen.Next(255), randonGen.Next(255));
    }
    }
