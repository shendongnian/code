    private void calculate_Click(object sender, EventArgs e)
    {
      int i          = int.Parse( textBox3.Text   ) ;
      int j          = int.Parse( textBox2.Text   ) ;
      int multiplyBy = int.Parse( multiplier.Text ) ;
      
      while ( i <= j )
      {
        int    answer = multiplyBy * i ;
        string value  = string.Format( "{0} times {1} = {2}" , i , mulitplyBy , answer ) ;
        listBox1.Items.Add( value ) ;
        ++i ;
      }
      
      return ;
    }
