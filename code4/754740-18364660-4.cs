    String txtBoxInput = "1234567890";
    try{
        //Some validation for Servy
       if(txtBoxInput!=null && txtBoxInput is String && txtBoxInput.Length>1)
       {
         String last2Numbs = txtBoxInput.Substring(txtBoxInput.Length-2);
    
         Int32 lasst2NumbersInt;
         bool result = Int32.TryParse(last2Numbs, out last2NumbsInt);
         if(result && last2NubsInts == MyInt)
           MessageBox.Show("Vat number correct");
         }
    }
    catch(Exception ServysException)
    {
        MessageBox.Show("Uhhhh ohh! An over engineered simple answer threw an error: " + ServysException.Message);
    }
