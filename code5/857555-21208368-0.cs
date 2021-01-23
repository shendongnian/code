        class Rule 
        { 
            public Func<string, bool> Test { get; set; }
            public string Message { get; set; }
        }
        private void txtNameandSurn_TextChanged(object sender, EventArgs e)
        {
            var rules = new List<Rule>()
            {
                new Rule() { Test = s => !String.IsNullOrEmpty(s), Message="String cannot be blank." },
                new Rule() { Test = s => (s.Length <= txtNameandSurn.MaxLength), Message="String cannot be longer than " + txtNameandSurn.MaxLength },
                new Rule() { Test = s => !s.Contains("#"), Message = "String cannot contain a hash character." }
            };
            var isValid = rules.All(r => r.Test(txtNameandSurn.Text));
            string[] message;
            if (!isValid)
            {
                message = rules.Where(r => r.Test(txtNameandSurn.Text) == false).Select(r => r.Message);
            }
            errorProvider1.SetError((message.Length > 0) ? (string.Join(';', message)) : "");
        }
