    public OleDbConnection Conexao() //Conexão
    {
       string strcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|DB.accdb";
       return new OleDbConnection(strcon);
    }
    
    void tabela()
    {
        try
        {    
            timer1.Enabled = false;
            using(var conexao = Conexao())
            {   
               conexao.Open();
               label1.Text = DateTime.Now.ToString();
               string bn = "select D2 from Planilha where D2='" + label1.Text + "'";
               textBox1.Text = label1.Text;
               using(OleDbCommand Queryyy = new OleDbCommand(bn, conexao))
               using(OleDbDataReader drr = Queryyy.ExecuteReader())
               {
                   if (drr.Read() == true)
                   {
                      try
                      {
                         MessageBox.Show("Hi");
                      }
                      catch (OleDbException ex)
                      {
                         MessageBox.Show("" + ex);
                      }
                   }
               }
            }
        }
        finally
        {
            timer.Enabled = true;
        }
    }
    
    private void timer1_Tick(object sender, EventArgs e)
    {
       tabela();
    }
