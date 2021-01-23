           Try
            {
            for (int i = 0; i < listViewSubject.Items.Count; i+=2)
            {
                string query = "INSERT INTO Std_Subjects (subject_id, std_reg_id) VALUES (" + Int.Parse(listViewSubject.Items[i]) + ", " + this.reg_id + ")";
                dal.InsertUpdateDelete(query);
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
