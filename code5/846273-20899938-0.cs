	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		var f2 = new Form2();
		if (f2.ShowDialog() == DialogResult.OK) {
			studentId.Text = f2.SelectedStudentId;
		} else {
			studentId.Text = "Select a Student!!!!";
		}
	}
