     private void Exercise_Load(object sender, EventArgs e)
    
    {  
     dgvStudents = new DataGridView();
    dgvStudents.Location = new Point(10, 10);
    dgvStudents.Size = new Size(645, 100);
    DataGridViewTextBoxColumn colFullName = new DataGridViewTextBoxColumn();
    dgvStudents.Columns.Add(colFullName);
    DataGridViewComboBoxColumn colGender = new DataGridViewComboBoxColumn();
    dgvStudents.Columns.Add(colGender);
    DataGridViewCheckBoxColumn colShowResume = new DataGridViewCheckBoxColumn();
    dgvStudents.Columns.Add(colShowResume);
    DataGridViewButtonColumn colShowPicture = new DataGridViewButtonColumn();
    dgvStudents.Columns.Add(colShowPicture);
    DataGridViewLinkColumn colEmailAddress = new DataGridViewLinkColumn();
    dgvStudents.Columns.Add(colEmailAddress);
    DataGridViewImageColumn colPicture = new DataGridViewImageColumn();
    dgvStudents.Columns.Add(colPicture);
                 
    Controls.Add(dgvStudents);
    }
