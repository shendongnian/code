    int i=2;
    protected void Button2_Click(object sender, EventArgs e)
    {
          string constr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data      
          Source=C:\Users\yogi\Documents\mydb.mdb";
          string cmdstr1 = select * from quant_level1 where id ="+i;
          OleDbConnection con1 = new OleDbConnection(constr);
          OleDbCommand com1 = new OleDbCommand(cmdstr1, con1);
          con1.Open();
          if(reader.Read())
          {
               label1.Text = String.Format("{0}", reader[1]);
               RadioButton1.Text = String.Format("{0}", reader[2]);
               RadioButton2.Text = String.Format("{0}", reader[3]);
               RadioButton3.Text = String.Format("{0}", reader[4]);
               RadioButton4.Text = String.Format("{0}", reader[5]);
               i++;
          }
          con1.Close();
    }
