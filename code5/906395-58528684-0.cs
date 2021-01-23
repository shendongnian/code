    private void tsbCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                frmCliente cliente = null;
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm is frmCliente)
                    {
                        cliente = (frmCliente)frm;
                        break;
                    }
                } 
                if (cliente == null)
                {
                    cliente = new frmCliente();
                    cliente.MdiParent = this; //Remove this line in case the IsMdiParent = True 
                    cliente.Show();
                }
                cliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel se conectar ao formulario devido ao erro: " + ex.Message,
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
