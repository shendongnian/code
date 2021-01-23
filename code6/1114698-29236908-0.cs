    private void button1_Click(object sender, EventArgs e)
    {
        // "reset"
        flowLayoutPanel1.EnableAll();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        // disable but the provide controls
        flowLayoutPanel1.DisableBut(checkBox1);
    }
    public static class Extensions
    {
        public static void EnableAll(this FlowLayoutPanel container)
        {
            foreach (Control control in container.Controls.OfType<Control>())
                control.Enabled = true;
        }
        public static void DisableBut(this FlowLayoutPanel container, params Control[] but)
        {
            foreach (Control control in but)
                control.Enabled = false;
        }
    }
