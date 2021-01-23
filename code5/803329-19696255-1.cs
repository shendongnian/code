    // Declare at the top
    object[,] conversions = {
        { "Kilometers to Miles", Kilometers_To_Miles},
        { "Miles to Kilometers", 1 / Kilometers_To_Miles},
        { "Feet to Meters", Feet_To_Meters},
        { "Meters to Feet", 1 / Feet_To_Meters},
	etc
	};
    
    // In Form Load
    foreach (string str in conversions)
    {
        cboConversions.Items.Add(str[0]);
    }
    // In btnCalculate_Click
    var conversionValue = conversions.First(x => x[0] == cboConventions.Text)[1];
    var convertedValue = (double)txtEntry.Text * conversionValue; // Need to validate is numeric
    txtAnswer.Text = convertedValue
  
