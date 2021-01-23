    private void pickSomethingMenuItem_Click(object sender, EventArgs e)
    {
        using (var picker = new PickerDialog())
        {
            if (picker.ShowDialog(this) == DialogResult.OK)
            {
                LoadSomething(picker.SomethingPicked);
            }
        }
    }
