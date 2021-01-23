    gradeLetter.Text = gradeLetter.Text.ToUpper();
    IDictionary<string, double> grades = new Dictionary<string, double>
    {
        {"A", 4.0},
        {"B", 3.0},
        {"C", 2.0},
        {"D", 1.0},
        {"F", 0.0}
    };
    
    if (!grades.ContainsKey(gradeLetter.Text)){
        MessageBox.Show("Invalid grade letter or has an empty textbox!", "Caution!", MessageBoxButton.OK);
    }
    else{
        gradeW = grades[gradeLetter.Text];
        // other stuff
    }
