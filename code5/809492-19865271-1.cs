    public void X()
    {
            foreach (char c in txtNumbers.Text)
            {
                sum = sum + (int.Parse(c.ToString()) * int.Parse(c.ToString()));
            }
            txtNumbers.Text = (sum.ToString());
            sum = 0;
            if (txtNumbers.Text == "1")
            {
                Response.Write("happy numbers");
                return;
            }else{
                 Response.Write("sad numbers");
            }
        }
