        private string FechaIni;
        private string FechaFin;
        private void btn_busca_Click(object sender, EventArgs e)
        {
            btn_busca.Enabled = false;
            pictureBox1.Visible = true;
            FechaIni = dateTimePicker1.Value.ToShortDateString();
            FechaFin = dateTimePicker2.Value.ToShortDateString();
            thread = new Thread(new ThreadStart(ejecuta_sql));
            thread.Start();
        }
        private void ejecuta_sql()
        {
            myConnection.Open();
            SqlCommand sql_command2;
            DataSet dt2 = new DataSet();
            sql_command2 = new SqlCommand("zzhoy", myConnection);
            sql_command2.CommandType = CommandType.StoredProcedure;
            sql_command2.Parameters.AddWithValue("@FechaIni", FechaIni);
            sql_command2.Parameters.AddWithValue("@FechaFin", FechaFin);
            SqlDataAdapter da2 = new SqlDataAdapter(sql_command2);
            da2.Fill(dt2, "tbl1");
            myConnection.Close();
            this.Invoke((MethodInvoker)delegate { 
                grid_detalle.DataSource = dt2.Tables[0];
                pictureBox1.Visible = false;
                btn_busca.Enabled = true;
            });
        }
