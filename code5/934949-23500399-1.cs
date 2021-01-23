    private void btnFechar_Click(object sender, EventArgs e)
    {
        var dialogResult = MessageBox.Show("Desjea Sair?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (dialogResult == DialogResult.Yes)
        {
            this.Close();
        }
    }
