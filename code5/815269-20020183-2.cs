    private void InsertBtn_Click(object sender, EventArgs e)
        {
           string Sqlquery = null;
           string  KarticaMString = "@Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Bojan\Desktop\Programiranje\School‌​\Kartice\Kartice\Kartice.mdf;Integrated Security=True;User Instance=True";
    
            using (SqlConnection conn = new SqlConnection(KarticaMString))
            {
                
                    Sqlquery = "INSERT INTO KarticaM (DateInsert, DateTransaction, Value, Purpose, DepositLift) VALUES (@DateInsert,@DateTransaction,@Value,@Purpose,@DepositLift)";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(Sqlquery, conn))
                    {
                        cmd.Parameters.Add("@DateInsert", SqlDbType.DateTime).Value = DateInsertPicker.Value;
                        cmd.Parameters.Add("@DateTransaction", SqlDbType.DateTime).Value = DateTransactionPicker.Value;
                        cmd.Parameters.Add("@Value", SqlDbType.Money).Value = ValueTxt.Text;
                        cmd.Parameters.Add("@Purpose", SqlDbType.Text).Value = PurposeTxt.Text;
                        cmd.Parameters.Add("@DepositLift", SqlDbType.Text).Value = DepositLiftCombobox.SelectedValue;
    
                        cmd.ExecuteNonQuery();                    
                    }
                   
                
            }
    
        }
