        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<Char, Encoding> dct = new Dictionary<char, Encoding>();
            string data = "How are you today";
            for(int i = 0; i < data.Length; i++)
            {
                Char C = data[i];
                if (!dct.ContainsKey(C))
                {
                    dct.Add(C, new Encoding(C));
                }
                dct[C].AddOccurence(i);
            }
            StringBuilder SB = new StringBuilder();
            foreach(Encoding enc in dct.Values)
            {
                if (SB.Length == 0)
                {
                    SB.Append(enc.ToString());
                }
                else
                {
                    SB.Append("," + enc.ToString());
                }
            }
            Console.WriteLine(SB.ToString());
        }
