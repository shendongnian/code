      private Boolean IsUnitedKingdom {
        get {
          return String.Equals(txtSenderCountryCode.Text, "United Kingdom") &&
                 String.Equals(cbRecipientCountry.Text, "United Kingdom"); 
        }
      }
    
      ...
      
      cmbWeightUnit.Enabled = !IsUnitedKingdom;
      myCombobox.Text = IsUnitedKingdom ? "Pound" : "KGS";
      ...
