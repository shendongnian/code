    protected void Button1_Click(object sender, EventArgs e)
    {
        int columnaId = 0;
        Botones botones = new Botones();
        columnaId = botones.SaveCVInfo2(nombre.Text, Apellidos.Text, EmpleoS.Text);
    	Session["columnaId"] = columnaId.ToString();
    }
