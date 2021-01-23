       double price= 12.00300;
       string op = null;
       price= Double.Parse(string.Format("{0:0.0000}", value));
       if ((price % 1) != 0)
         op =   string.Format("{0:#.0000}", price);
       else
         op =  string.Format("{0}", price);
