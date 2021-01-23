    Dictionary<int, Func<spGetDataRow,bool>> dict = new Dictionary<int, Func<spGetDataRow, bool>>()
    {
        {0, (spGetDataRow a) => true},                      // No checkboxes checked return all
        {1, (spGetDataRow a) => a.Avg < 2},                 // Only checkbox1 checked
        {2, (spGetDataRow a) => a.Avg >= 2 && a.Avg < 3},   // Only checkbox2 checked
        {3, (spGetDataRow a) => a.Avg ????},                // CheckBox1 AND Checkbox2 checked
        {4, (spGetDataRow a) => a.Avg >= 3 && a.Avg < 6},   // CheckBox3 checked
        {5, (spGetDataRow a) => a.Avg ????},                // CheckBox3 + ChecBox1 checked
        {6, (spGetDataRow a) =>  a.Avg >= 2 && a.Avg < 6},  // CheckBox3 + CheckBox2 checked
        {7, (spGetDataRow a) => a.Avg ????},                // CheckBox3 + CheckBox2 + CheckBox1 checked    
        {8, (spGetDataRow a) => a.Avg >= 6},                // CheckBox4 checked
        {9, (spGetDataRow a) => a.Avg ????},                // CheckBox4 + CheckBox1 checked
        {10, (spGetDataRow a) => a.Avg ????},               // CheckBox4 + CheckBox2 checked
        {11, (spGetDataRow a) => a.Avg ????},               // CheckBox4 + CheckBox2 + CheckBox1 checked    
        {12, (spGetDataRow a) => a.Avg ????},               // CheckBox4 + CheckBox3 checked
        {13, (spGetDataRow a) => a.Avg ????},               // CheckBox4 + CheckBox3 + CheckBox1 checked
        {14, (spGetDataRow a) => a.Avg ????},               // CheckBox4 + CheckBox3 + CheckBox2 checked
        {15, (spGetDataRow a) => true}                      // All checkboxes selected return all
    };
