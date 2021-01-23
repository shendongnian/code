    private void Textbox1_TextChanged(object sender, EventArgs e){
        string input = Textbox1.Text;
        string pattern = @"([A-Z][a-z]?\d*|[A-Z]?\d*)";
        string[] substrings = Regex.Split(input, pattern);
    
        var result = MoleculeweightCalculator(substrings);
    
        Textbox2.Text = Convert.ToString(result.Sum());
    }
    
    private static List<double> MoleculeweightCalculator(string[] substrings){
        List<double> MoleculeWeightList = new List<double>();
    
        foreach (string match in substrings){
            if (match == "H")
                MoleculeWeightList.Add(1.008);
        }
    
        return MoleculeWeightList;
    }
