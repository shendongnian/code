    // Declare at the top
    Dictionary<string, double> conversions = {
        { "Kilometers to Miles", Kilometers_To_Miles},
        { "Miles to Kilometers", 1 / Kilometers_To_Miles},
        { "Feet to Meters", Feet_To_Meters},
        { "Meters to Feet", 1 / Feet_To_Meters},
	etc
	};
    
    // In Form Load
    foreach (string str in conversions.Keys)
    {
        cboConversions.Items.Add(str);
    }
    // In btnCalculate_Click
    var conversionValue = conversions[cboConversions.Text];
    var convertedValue = (double)txtEntry.Text * conversionValue; // Need to validate is numeric
    txtAnswer.Text = convertedValue
  
