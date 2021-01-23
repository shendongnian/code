    private void InitializeMedicinesAutoComplete()
    {
       var searchMed = Lookup.Medicines
           .Where(d => d.DosageForm.Equals(cmbType.SelectedValue.ToString())).ToList(); 
    
       var source = new AutoCompleteStringCollection();
       foreach (var med in searchMed)
       {
          // **DisplayMemberText mean any field that you want to display in searching list
          source.Add(med.DisplayMemberText); 
       }
       txtMedicines.AutoCompleteMode = AutoCompleteMode.Suggest;
       txtMedicines.AutoCompleteSource = AutoCompleteSource.CustomSource;
       txtMedicines.AutoCompleteCustomSource = source;
    }
    
    private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
    {
       InitializeMedicinesAutoComplete();
    }
