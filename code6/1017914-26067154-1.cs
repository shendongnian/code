    private Stack<ComboBox> dynamicBoxes = new Stack<ComboBox>();
    private void button1_Click(object sender, EventArgs e) {
        ComboBox cboRun = new ComboBox();
        cboRun.Location = new System.Drawing.Point(20, 18 + (20 * c));
        cboRun.Size = new System.Drawing.Size(200, 25);
        dynamicBoxes.Push(cboRun);
        this.Controls.Add(cboRun);     
    }
    private void button2_Click(object sender, EventArgs e)  {
        var lastComboBox = dynamicBoxes.Pop();
        Controls.Remove(lastComboBox);
    }
