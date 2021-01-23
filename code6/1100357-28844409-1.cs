    BindingList<Department> Departments { get; set; }
    private void OnCellsValueChanged(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex == colDepartment.Index)
      {
        this.Departments[e.RowIndex].Employees = repository.GetEmployeeByDepartments(this.dataGridView1.CurrentCell.EditedFormattedValue.ToString());
        DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)this.dataGridView1.CurrentRow.Cells[colComboEmployeesByDpt.Index];
        cell.DataSource = this.Departments[e.RowIndex].Employees;
      }
    }
    private void btnLoad_Click(object sender, EventArgs e)
    {
      //this.dataGridView1.Rows.Clear(); // Needed if the button can be clicked repeatedly.
      this.Departments = repository.GetDepartments();
      foreach (Department department in this.Departments)
      {
        department.Employees = repository.GetEmployeeByDepartments(department.Name);
        DataGridViewRow row = (DataGridViewRow)(dataGridView1.Rows[0].Clone());
        DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell)(row.Cells[0]);
        textCell.Value = department.Name;
        DataGridViewComboBoxCell comboCell = (DataGridViewComboBoxCell)(row.Cells[1]);
        comboCell.DataSource = department.Employees;
        comboCell.DisplayMember = "FullName";
        dataGridView1.Rows.Add(row);
      }
    }
