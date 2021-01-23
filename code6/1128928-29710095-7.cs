        private string[] lengths;
        private void SandC_Load(object sender, EventArgs e)
        {
            lengths = System.IO.File.ReadAllLines("Units.txt");
            for (var i = 0; i < lengths.Length; i++)
            {
                var line = lengths[i];
                var s = line.Split(',')[0];
                var itemText = string.Format("{0}.{1}", i + 1, s);
            }
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            // you dont need to read those again you've stored the in the private field this.lengths
            // string[] lengths = File.ReadAllLines("Units.txt");
            var units = new double[lengths.Length];
            for (var i = 0; i < lengths.Length; i++)
            {
                var line = lengths[i];
                var s = line.Split(',')[1])
                ;
                units[i] = Convert.ToDouble(s);
            }
        }
