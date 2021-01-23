    private void frmStudentScores_Load(object sender, EventArgs e)
            {
                lstStudents.Items.Clear();
                lstStudents.Items.Add("Joe Smith|93|92|98");
                lstStudents.Items.Add("Mike Jones|56|61|33");
                lstStudents.Items.Add("Rita Jackson|100|89|96");
                lstStudents.SelectedIndex = 0;
                txtDisplay.Text = lstStudents.Items[0].ToString();
                btnUpdate.Enabled = false; 
