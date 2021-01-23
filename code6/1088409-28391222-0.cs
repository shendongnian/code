        private List<Keys> tmpVowelz = null;
        private Random randomizer = new Random();
        private List<Keys> vowelz = new List<Keys>() {
            Keys.A,
            Keys.A,
            Keys.B,
            Keys.B
        };
        
        public void vowelbutton_Click(object sender, EventArgs e)
        {
            if (tmpVowelz == null)
            {
                listBox1.Items.Clear();
                tmpVowelz = new List<Keys>(vowelz);
            }
            if (tmpVowelz.Count > 0)
            {
                int index = randomizer.Next(tmpVowelz.Count);
                Keys key = tmpVowelz[index];
                listBox1.Items.Add(tmpVowelz[index]);
                tmpVowelz.RemoveAt(index);
                if (tmpVowelz.Count == 0)
                {
                    tmpVowelz = null;
                }
            }
        }  
