        Dictionary< double,int> table=new Dictionary<double, int>();
 
        private void btnChoose_Click(object sender, EventArgs e)
        {
            var number = new Random();
            double chose = number.Next(1, 7);
            table[chose]++;
            txtnumber.Text = chose.ToString();
            txtnumber2.Text = table[2];
        }
