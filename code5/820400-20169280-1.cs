    class labels
    {
        public static void addLabel(Control ctrl)
        {
            Label test = new Label();
            test.Location = new Point(1, 1);
            test.Text = "Working";
            ctrl.Controls.Add(test);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        labels.addLabel(this);
    }
