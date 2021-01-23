    private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string volunteerID = updtIDTextBox.Text;
                string volunteerName = updtNameTextBox.Text;
                string volunteerZone = updtZoneTextBox.Text;
                string volunteerStreet = updtStreetTextBox.Text;
                int volunteerSex = updtMaleRadioButton.Checked ? 0 : 1;
                DateTime volunteerBirthday = updtBirthdayDateTimePicker.Value;
                if (updtHomePhoneTextBox.Text == "")
                    updtHomePhoneTextBox.Text = "0";
                int volunteerHomePhone = int.Parse(updtHomePhoneTextBox.Text);
                if (updtWorkPhoneTextBox.Text == "")
                    updtWorkPhoneTextBox.Text = "0";
                int volunteerWorkPhone = int.Parse(updtWorkPhoneTextBox.Text);
                if (updtMobile1TextBox.Text == "")
                    updtMobile1TextBox.Text = "0";
                int volunteerMobile1 = int.Parse(updtMobile1TextBox.Text);
                if (updtMobile2TextBox.Text == "")
                    updtMobile2TextBox.Text = "0";
                int volunteerMobile2 = int.Parse(updtMobile2TextBox.Text);
                string volunteerEmail = updtEmailTextBox.Text;
                string volunteerJob = updtJobTextBox.Text;
                string volunteerAffiliation = updtAffiliationTextBox.Text;
                //The solution start from here
                int volunteerEducation = 0;
                if (radioButton10.Checked)
                    volunteerEducation = 1;
                else if (radioButton11.Checked)
                    volunteerEducation = 2;
                else if (radioButton12.Checked)
                    volunteerEducation = 3;
                else if (radioButton14.Checked)
                    volunteerEducation = 5;
                else if (radioButton15.Checked)
                    volunteerEducation = 6;
                else if (radioButton16.Checked)
                    volunteerEducation = 7;
                else if (radioButton17.Checked)
                    volunteerEducation = 8;
                else if (radioButton18.Checked)
                    volunteerEducation = 9;
                //end solution
                string volunteerEducationPlace = addEducationPlaceTextBox.Text;
                string volunteerEducationDepartmen = addEducationDepartmentTextBox.Text;
                //same above
                int volunteerInteresting = 0;
                if (updtIntrstMdcnRadioButton.Checked)
                    volunteerInteresting = 1;
                else if (updtIntrstSosclRadioButton.Checked)
                    volunteerInteresting = 2;
                else if (updtIntrstLrnRadioButton.Checked)
                    volunteerInteresting = 3;
                else if (updtIntrstTrnRadioButton.Checked)
                    volunteerInteresting = 4;
                //end
                string volunteerNotes = addNotesTextBox.Text;
                int x = dataGridViewX1.SelectedRows[0].Index;
                UpdateVolunteer(volunteerID, volunteerName, volunteerZone, volunteerStreet, volunteerSex, volunteerBirthday, volunteerHomePhone, volunteerWorkPhone, volunteerMobile1, volunteerMobile2, volunteerEmail, volunteerJob, volunteerAffiliation, volunteerEducation, volunteerEducationPlace, volunteerEducationDepartmen, volunteerInteresting, volunteerNotes);
                showVolunteers(x);
                updtIDTextBox.Text = "";
                updtNameTextBox.Text = "";
                updtZoneTextBox.Text = "";
                updtStreetTextBox.Text = "";
                updtBirthdayDateTimePicker.Value = DateTime.Now;
                updtHomePhoneTextBox.Text = "";
                updtWorkPhoneTextBox.Text = "";
                updtMobile1TextBox.Text = "";
                updtMobile2TextBox.Text = "";
                updtEmailTextBox.Text = "";
                updtJobTextBox.Text = "";
                updtAffiliationTextBox.Text = "";
                updtEducationPlaceTextBox.Text = "";
                updtEducationDepartmentTextBox.Text = "";
                updtNotesTextBox.Text = "";
            }
            catch (SqlException sql)
            {
                MessageBoxEx.Show(sql.Message);
            }
        } 
