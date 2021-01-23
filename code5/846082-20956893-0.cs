    namespace ProgTesting {
    public partial class Form5 : Form {
    private bool doNothing = false;
    public Form5() {
      InitializeComponent();
      cmdAdvanced.Visible = false;
    }
    private void cmdSimple_Click(object sender, EventArgs e) {
      if (panel2.Visible) {
        panel2.Visible = false;
        doNothing = true;
        this.MinimumSize = new Size(this.Width, this.Height - panel2.Height);
        this.Height = this.Height - panel2.Height;
        doNothing = false;
        cmdSimple.Visible = false;
        cmdAdvanced.Visible = true;
      }
    }
    private void cmdAdvanced_Click(object sender, EventArgs e) {
      if (!panel2.Visible) {
        panel2.Visible = true;
        doNothing = true;
        this.Height = this.Height + panel2.Height;
        this.MinimumSize = new Size(this.Width, this.Height);
        doNothing = false;
        cmdAdvanced.Visible = false;
        cmdSimple.Visible = true;
      }
    }
    private void Form5_SizeChanged(object sender, EventArgs e) {
      if (!doNothing)
        if (panel2.Visible)
          panel3.Height = this.ClientSize.Height - panel1.Height - panel2.Height - panel4.Height;
        else
          panel3.Height = this.ClientSize.Height - panel1.Height - panel4.Height;
    }
    }
    }
