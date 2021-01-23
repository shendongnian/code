    private void Form1_Load(object sender, EventArgs e)
        {
            DateTime previousPayment =new DateTime();
            DateTime nextPayment=new DateTime();
            getdate(ref previousPayment, ref nextPayment);
        }
        public void getdate(ref  DateTime previousPayment, ref DateTime nextPayment)
        {
            previousPayment = System.DateTime.Now;
            nextPayment = System.DateTime.Now.AddDays(1);
        }
