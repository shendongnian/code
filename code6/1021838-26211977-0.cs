    Dictionary<string, List<string>> dict;       
        private void Form1_Load(object sender, EventArgs e)
        {
            dict = new Dictionary<string, List<string>>()
            {
                { "A", new List<string> { "A1", "A2", "A3", "A4", "A5" }},
                { "B", new List<string> { "B1", "B2", "B3", "B4", "B5" }},
                { "C", new List<string> { "C1", "C2", "C3", "C4", "C5" }},
            };
            cb1.DisplayMember = "Key";
            cb1.DataSource = dict.ToList();
            
        }
        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {                      
                cb2.DataSource = dict[cb1.Text];              
        }
