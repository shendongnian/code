                Open_VCS_Connection();
            string sql_query_main = "SELECT * FROM VCS_DATA WHERE OPERATOR ='" + operator_comboBox.Text.ToString() + "' AND ROTATION = '" + rotation_comboBox.Text.ToString() + "' AND ENTRY_DATE = '" + entry_dateTimePicker.Value.ToShortDateString() + "'";
            main_ds = new DataSet();
            main_da = new SQLiteDataAdapter(sql_query_main, dbConnection);
            sqlcmdBuilder = new SQLiteCommandBuilder(main_da);
            SQLiteCommand sqlcmdInsert = new SQLiteCommand("INSERT INTO VCS_DATA"
            +" (operator, rotation, entry_date, created_date, callsign, veh_type, ntc_number, bumper_number, line_number, dci_orig, dci_repl, pid_orig, pid_repl, pl_status, sawe_kill, sawe_res, cntlr_kill, cntlr_res, weapon, comments)"
            +" VALUES"
            +" (@operator, @rotation, @entry_date, @created_date, @callsign, @veh_type, @ntc_number, @bumper_number, @line_number, @dci_orig, @dci_repl, @pid_orig, @pid_repl, @pl_status, @sawe_kill, @sawe_res, @cntlr_kill, @cntlr_res, @weapon, @comments)");
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@operator", DbType.String) { Value = operator_comboBox.Text.ToString() });
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@rotation", DbType.String) { Value = rotation_comboBox.Text.ToString() });
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@entry_date", DbType.String) { Value = entry_dateTimePicker.Value.ToShortDateString() });
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@created_date", DbType.DateTime) { Value = DateTime.Now.ToLocalTime() });
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@callsign", DbType.String, "callsign"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@veh_type", DbType.String, "veh_type"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@ntc_number", DbType.String, "ntc_number"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@bumper_number", DbType.String, "bumper_number"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@line_number", DbType.String, "line_number"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@dci_orig", DbType.Byte, "dci_orig"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@dci_repl", DbType.Byte, "dci_repl"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@pid_orig", DbType.Byte, "pid_orig"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@pid_repl", DbType.Byte, "pid_repl"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@pl_status", DbType.Byte, "pl_status"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@sawe_kill", DbType.Byte, "sawe_kill"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@sawe_res", DbType.Byte, "sawe_res"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@cntlr_kill", DbType.Byte, "cntlr_kill"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@cntlr_res", DbType.Byte, "cntlr_res"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@weapon", DbType.Byte, "weapon"));
            sqlcmdInsert.Parameters.Add(new SQLiteParameter("@comments", DbType.String, "comments"));
            main_da.InsertCommand = sqlcmdInsert;
            main_da.Fill(main_ds);
            main_dataGridView.DataSource = main_ds.Tables[0].DefaultView;
