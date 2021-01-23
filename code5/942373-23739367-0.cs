    double item = 0;
   
     if(double.TryParse(tbx_TotalVikt.Text, out item))
                {
                    totalWeight += item;
                    
                }
        tbx_TotalVikt.Text = totalWeight.ToString();
