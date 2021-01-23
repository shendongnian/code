    private void Interfaz_FormClosing(object sender, FormClosingEventArgs e)
    {
       If(e.CloseReason == CloseReason.UserClosing)
       {
           DialogResult salir = MessageBox.Show("¿Seguro que desea cerrar el programa?",
                                "Advertencia", MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question);
            if (salir == DialogResult.No)
                e.Cancel = true;
        }
     }
