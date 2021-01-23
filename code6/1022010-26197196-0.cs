    if(myReader.Read())
    {
       // changed the while loop to an if. While loop is useless because if more than 1 row is returned
    // then it just keeps setting the same textboxes over and over.
    
    // check to make sure Cash isn't null
        if(!myReader.IsDbNull(myReader.GetOrdinal("Cash")))
        {
              TextBox3.Text = myReader["Cash"].ToString();
              // setup a temporary variable to hold the output of Cash in
              decimal cash = 0;
              // remove trailing whitespace and replace a currency with no space and attempt to convert
              if(decimal.TryParse(myReader["Cash"].ToString().Trim().Replace("$",""),out cash))
              { 
                  // set TextBox4 only if the cash really is a value we can work with and subtract Total from 
                  TextBox4.Text = (cash - (decimal)Total).ToString();
              }
        }
    }
