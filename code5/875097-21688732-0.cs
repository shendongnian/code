It is best practice to use [StringBuilder][1].  In addition, using the code you posted, if the user un-checks a box, you aren't removing those from the string.  I would suggest building the string inside the displayOrderToolStripMenuItem_Click event like so:
    private void displayOrderToolStripMenuItem_Click(object sender, EventArgs e)
    {
        StringBuilder message = new StringBuilder();
        if (chkSkis.Checked == true)
        {
            message.AppendLine(chkSkis.Text);
        }
        if (chkGoogles.Checked == true)
        {
            message.AppendLine(chkGoogles.Text);
        }
        MessageBox.Show("You chose the following equipments:\n" + message,
                    "Flyers Sports Club");
    }
