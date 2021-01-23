    	private lengths[];
    	
    	private void SandC_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = true;
    
            this.lengths = File.ReadAllLines("Units.txt");
            
    		for(int i = 0; i < lengths.Length; i++)
    		{
    			string line = this.lengths[i];
    			string s = line.Split(new Char[]{','})[0];
    			string itemText = string.Format("{0}.{1}", count + 1, s);
                lbLengths.Items.Add(itemText);
    		}      
       }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            string orginalunits = tborginalUnits.Text;
            int orginalunits1;
            string desiredunits = tbDesiredunits.Text;
            int desiredunits1;
            string LengthtoConvert = tbConvert.Text;
            double LengthtoConvert1;
    		// you dont need to read those again you've stored the in the private field this.lengths
            // string[] lengths = File.ReadAllLines("Units.txt");
            
            double[] units = new double[lengths.Length];
    		
    		foreach(int i = 0; i < Lengths.Length; i++)
    		{
    			string s = line.Split(new Char[] { ',' })[1]);
    			units[i] = Convert.ToDouble(s);
    		}
    	}
