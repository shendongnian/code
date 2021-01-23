    public void deletePatientById(long id)
    {
        conn.Open();
        using (SQLiteCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = String.Format("DELETE FROM patient WHERE patient_id={0}", id);
            cmd.ExecuteNonQuery();
        }
        conn.Close();
        MessageBox.Show("Patient: " + id.ToString() + " gelöscht");
    }
