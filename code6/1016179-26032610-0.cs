            private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/00/0000";
            maskedTextBox1.ValidatingType = typeof(System.DateTime);
            maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);
        }
        void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                MessageBox.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.");
            }
            else
            {
                DateTime userDate = (DateTime)e.ReturnValue;
                if (userDate >= DateTime.Now)
                {
                    
                    MessageBox.Show("The date in this field must be less or equal than today's date.");
                    e.Cancel = true;
                }
            }
        }
