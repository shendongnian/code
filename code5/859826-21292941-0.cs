      string MenOrWomen;
      void rdbtnTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnTwo.Checked.Equals(true))
            {
                MenOrWomen = "Women";
            }
            else
            {
                MenOrWomen = "Men";
            }
        }
        
        void rdbtnOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnOne.Checked.Equals(true))
            {
                MenOrWomen = "Men";
            }
            else
            {
                MenOrWomen = "Women";
            }
        }
        int i = 1;
        void btnOne_Click(object sender, EventArgs e)
        {
            lstOne.Items.Add(i + MenOrWomen);
            i++;
        }
