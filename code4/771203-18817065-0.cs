    public string txt { get; set; } //A so called property
    private void OK_button_Click(object sender, EventArgs e)
    {
        txt = textBox.Text;
        this.DialogResult = System.Windows.Forms.DialogResult.OK;
        this.Close();
    }
