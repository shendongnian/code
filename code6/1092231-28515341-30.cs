        private void cancel_Click(object sender, EventArgs e)
        {
            ClassName.RollbackTransaction();
            conn.Close();
        }
        private void ok_Click(object sender, EventArgs e)
        {
            ClassName.CommitTransaction();
            conn.Close();
        }
