	int result=0;
	DateTime val;
	TimeSpan Timeval;
	String str ="INSERT INTO correspondencia_FFAA (no_reg, fecha_cre, hora_crea, corres_tipo,num_corres, dfecha, origen, enviar_a, estado_corres, asunto_corres, mens_corres, usuario,recibido)values(@registro,@fecha_creacion,@hora_creacion,@tipo_corres,@numero,@dfecha, @origen,@enviar_a,@estado,@asunto,@mensaje,@usuario,@recibo)";
	comando.CommandText= str;
	if(int.TryParse(txtNoReg.Text,out result))
	{
		comando.Parameters.Add("@registro",SqlDbType.BigInt).Value = txtNoReg.Text;
	}
	if(DateTime.TryParse(txtFechCrea.Text,out val))
	{
		comando.Parameters.Add("@fecha_creacion", SqlDbType.Date).Value = txtFechCrea.Text;
	}
	if(TimeSpan.TryParse(txtHorCrea.Text,out TimeVal))
	{
		comando.Parameters.Add("@hora_creacion", SqlDbType.Time).Value = txtHorCrea.Text;
	}
	if(int.TryParse(cbbTipo.Text,out result))
	{
		comando.Parameters.Add("@tipo_corres", SqlDbType.VarChar, 30).Value = cbbTipo.Text;
	}
	if(int.TryParse(txtNo.Text,out result))
	{
		comando.Parameters.Add("@numero", SqlDbType.BigInt).Value = txtNo.Text;
	}
	if(DateTime.TryParse(txtDF.Text,out val))
	{
		comando.Parameters.Add("@dfecha", SqlDbType.DateTime).Value = txtDF.Text;
	}
	comando.Parameters.Add("@origen", SqlDbType.VarChar, 35).Value = txtOrigen.Text;
	comando.Parameters.Add("@enviar_a", SqlDbType.VarChar, 35).Value = txtDestino.Text;
	comando.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = cbbEstado.Text;
	comando.Parameters.Add("@asunto", SqlDbType.VarChar, 100).Value = txtAsunto.Text;
	comando.Parameters.Add("@mensaje", SqlDbType.VarChar, 500).Value = rtxtMensaje.Text;
	comando.Parameters.Add("@usuario", SqlDbType.VarChar, 40).Value = txtUsuario.Text;
	comando.Parameters.Add("@recibo", SqlDbType.VarChar, 40).Value = txtRecibido.Text;
