    try
    {
        if (e.ColumnIndex > 0 && e.RowIndex > 0)
        {
            EditUser eu = new EditUser();
            eu.UserId = DGV1.Rows[e.RowIndex].Cells[1].Value.ToString();
            FormFunctions.OpenMdiDataForm(Program.GetMainMdiParent(), eu);    
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
