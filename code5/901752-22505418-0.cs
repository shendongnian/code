    public void CheckCheckBoxes2()
    {
        if (checkBox2.Checked == false)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";
            dateTimePicker2.Text = null;
            dateTimePicker2.Enabled = false;
            textBox2.Text = null;
            textBox2.Enabled = false;
        }
        else
        {
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Enabled = true;
            textBox2.Enabled = true;
        }
    }
