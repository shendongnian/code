    private void button1_Click(object sender, EventArgs e)
    {
        TimeSpan difference = getDateDifference(new DateTime(2014, 2, 20), dateTimePicker1.Value);
        if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
        {
            MessageBox.Show(" Patient id, first name and last name cannot be empty");
        }
        else
           try
           {
               foreach (Patient patientinfoIndex in patientInfo)
               {
                   patientInfo[itemCountInteger].patientidString = textBox1.Text;
                   patientInfo[itemCountInteger].firstNameString = textBox2.Text;
                   patientInfo[itemCountInteger].lastNameString = textBox3.Text;
                   patientInfo[itemCountInteger].dateString = dateTimePicker1.Text;
                   patientInfo[itemCountInteger].differenceAsString= difference.Days.ToString();
    
                   string names = patientInfo[itemCountInteger].patientidString + "  " +   patientInfo[itemCountInteger].firstNameString + " " + patientInfo[itemCountInteger].lastNameString;
                   listBox1.Items.Add(names);
                   itemCountInteger++;
                   listBox1.SelectedItem = names;
            } 
        }
        catch
        {
            MessageBox.Show("Contacts are limited to 20. Please delete some contacts prior to adding more.");
        }
    }
