    public partial class confSelMenu : Form
    {
    int circSeg;
    public confSelMenu(string mainChoice, string secondChoice, int segNum)
    {
        InitializeComponent();
        circSeg = segNum;
        label2.Text = mainChoice;
        label3.Text = secondChoice;
        label4.Text = segNum.ToString();
    }
