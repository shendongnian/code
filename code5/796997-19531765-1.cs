        private void btnHASH_Click(object sender, EventArgs e)
        {
            if (codeTXT.Text == "1245")
            {
                accessboxLIST.Items.Add(DateTime.Now.ToString() + " Security Team");
                codeTXT.Clear();
            }
            else if (codeTXT.Text == "007")
            {
                accessboxLIST.Items.Add(DateTime.Now.ToString() + " James Bond");
                codeTXT.Clear();
            }
        }
