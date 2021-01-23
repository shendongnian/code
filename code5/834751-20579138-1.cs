    private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_action == "edit")
                {
                    update(_id, int.Parse(cbSupplier.ValueMember), dtpTRXdate.Value, dtpDUEdate.Value, txtRemarks.Text.ToString(), _conn);
                }
                else
                {
                    insert(int.Parse(cbSupplier.ValueMember), dtpTRXdate.Value, dtpDUEdate.Value, txtRemarks.Text.ToString(), _conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
       }
    public void insert(int sup_ID, DateTime TRX_date, DateTime DUE_date, string remarks, MySqlConnection conn)
        {
            MessageBox.Show(sup_ID.ToString() + " " + TRX_date.ToShortDateSTring() + " " + DUE_date.ToShortDateSTring() + " " + remarks);
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "INSERT INTO PO_HEADER VALUES(@value1,@sup_ID,@TRX_date,@ DUE_date,@remarks)";
            command.Parameters.AddWithValue("@value1",DBNull.Value);
            command.Parameters.AddWithValue("@sup_ID",sup_ID);
            command.Parameters.AddWithValue("@TRX_date",TRX_date);
            command.Parameters.AddWithValue("@DUE_date",DUE_date);
            command.Parameters.AddWithValue("@remarks",remarks);
            command.ExecuteNonQuery();
        }
    public void update(int id, int sup_id, string trx_date, string due_date, string remarks, MySqlConnection conn)
        {
            MySqlCommand command = new MySqlCommand();
            command.Connection = conn;
            command.CommandText = "UPDATE PO_HEADER SET SUPPLIER_ID=@sup_id,TRX_DATE=@trx_date,DUE_DATE=@due_date,REMARKS=@remarks WHERE ID=@id";
            command.Parameters.AddWithValue("@sup_ID",sup_ID);
            command.Parameters.AddWithValue("@trx_date",trx_date);
            command.Parameters.AddWithValue("@due_date",due_date);
            command.Parameters.AddWithValue("@remarks",remarks);
            command.Parameters.AddWithValue("@sup_ID",id);
            command.ExecuteNonQuery();
        }
