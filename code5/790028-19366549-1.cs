    protected void Button1_Click(object sender, EventArgs e)
        {
            Botones botones = new Botones();
            botones.SaveCVInfo2(nombre.Text, Apellidos.Text, EmpleoS.Text, DireccionPersonal.Text, RadioButtonList6.SelectedItem.Text);
        }
