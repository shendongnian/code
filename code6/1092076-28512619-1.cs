    public partial class Form1
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            script1.StatusTextChanged += (sender1, e1) => statusLabel.Text = script1.Text;
            script1.Run();
            ...
            script30.StatusTextChanged += (sender1, e1) => statusLabel.Text = script30.Text;
            script30.Run();
        }
    }
