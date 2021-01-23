    private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            int count = this.dgvAllFaculty.SelectedRows.Count;
            foreach (DataGridViewRow item in this.dgvAllFaculty.SelectedRows)
            {
                int i = item.Index;
                FacultyMember member = memberList[i];
                memberList.RemoveAt(i);
                Save();
            }
            if (count > 1)
            {
                MessageBox.Show(String.Format("{0} faculty memebers deleted", count));
            }
            else
            {
                MessageBox.Show("Faculty Member Deleted");
            }
            // Load the newest data from file before refreshing the view
            ViewAll_Load(sender, e);
            this.Refresh();
        }
