    private void Form1_Load(object sender, EventArgs e)
            {
                RunMethod();           
            }
    
        private void RunMethod()
        {
            string newstatus = "accept";
            if (farmer(newstatus))
            {
                timer1.Start();
            }
        }
        private bool farmer(string value)
        {
            bool isValid = false;
            if (value == "accept")
                isValid = true;
            return isValid;
        }
