    private void button1_Click(object sender, EventArgs e)
    {
        CalculateVowels cal = new CalculateVowels(this, text);
    }
    class CalculateVowels
    {
        public CalculateVowels(Form1 f, string text)
        {
            int counter = 0;
            int l = text.Length;
            for (int i = 0; i < l; i++)
            {
                if (text[i] == 'a' || text[i] == 'e' || text[i] == 'i' || text[i] == 'o' || text[i] == 'u')
                {
                    counter++;
                }
            }
            outings(f, counter);
        }
    
        public void outings(Form1 f, int vowels)
        {
            string a = vowels.ToString();
            f.SetText(a);
        }
    }
