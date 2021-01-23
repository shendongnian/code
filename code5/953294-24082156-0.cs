    private void btnOpenModalWindow_Click(object sender, EventArgs e)
        {
            using (var modalForm = new modalForm(EventDetails))
            {
                if (modalForm.ShowDialog() == DialogResult.OK)
                {
                   this.Close();
                }
            }
        }
