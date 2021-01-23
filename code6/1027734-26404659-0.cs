    private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Font = new Font("Mangal", 10);
                textBox2.Font = new Font("Mangal", 10);
                ToHindiInput();
                
                
            }
            else 
            {
                textBox1.Font = new Font("Times New Roman", 10);
                textBox2.Font = new Font("Times New Roman", 10);
                ToEnglishInput();
            }
        }
    public void ToEnglishInput()
        {
            string CName = "";
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                CName = lang.Culture.EnglishName.ToString();
                if (CName.StartsWith("English"))
                {
                    InputLanguage.CurrentInputLanguage = lang;
                }
            }
        }
        public void ToHindiInput()
        {
            string CName = "";
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                CName = lang.Culture.EnglishName.ToString();
                if (CName.StartsWith("Hindi"))
                {
                    InputLanguage.CurrentInputLanguage = lang;
                }
            }
        }
