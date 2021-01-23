      decimal xxxyyy = Convert.ToDecimal(WeightTextBox.Text); 
        
        if(!xxxyyy .ToString().Contains(".00))
        {
          AddReconItem.ItemWeight=xxxyyy.ToString() +".00";
        }
        else
        {
         AddReconItem.ItemWeight=xxxyyy.ToString() ;
        }
