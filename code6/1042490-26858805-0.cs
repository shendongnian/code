    private void Button_Click_2(object sender, EventArgs e)
    {
        DateTime tempDate;
        if (listBoxPeople.SelectedIndex != -1 && DateTime.TryParse(textBoxDOB.Text, out tempDate))
        {
            Person p = listBoxPeople.SelectedItem as Person;
            p.Name = textBoxName.Text;
            p.DOB = tempDate;
        }
    }
