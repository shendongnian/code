    private void button1_Click(object sender, EventArgs e)
        {
            try
            {                
                adp1.SelectCommand = cmd1; // cmd1 is your SELECT command
                OleDbCommandBuilder cb = new OleDbCommandBuilder(adp1);
                adp1.Update(dt); //here I hope you won't get error :-)
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }
 
