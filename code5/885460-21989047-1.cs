    private void button1_Click_1(object sender, EventArgs e)
        {
            
            var sel = listBox1.SelectedItem;
            Regex reg = new Regex(@"[0-9\.]+");
              var res =   reg.Match(sel.ToString());
            //if you want to compute the total 
            double total = 0; 
            var allItems = listBox1.SelectedItems;
            foreach (var item in allItems)
            {
                double dres = double.Parse(reg.Match(sel.ToString()).Value);
                total = dres + total; 
                
            }
            tblkTotal.Text = string.Format("Total Expenses\t{0}", total);
        }
