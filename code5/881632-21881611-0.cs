    class SingleItem
    {
        public int val1 { get; set; }
        public int val2 { get; set; }
        public string str { get; set; }
        public override string ToString()
        {
            return str;
        }
    
    }
    
    ...
    
     private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var obj = ((SingleItem)comboBox1.SelectedItem).val1; 
    }
