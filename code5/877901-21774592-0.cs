    List<double> dx = new List<double>();
    List<double> dy = new List<double>();
    if(DialogResult.OK == openFileDialog1.ShowDialog())
    {
        int x = 1;
        if(openFileDialog1.FileName != string.Empty)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            // Load everything in an IEnumerable of strings
            var lines = File.ReadLines(openFileDialog1.FileName);
            // start the enumeration
            foreach(string s in lines)
            {
                double temp;
                // If on even line put the value in the dy list
                if((x % 2) == 0)
                {
                    if(double.TryParse(s, NumberStyles.Any, ci, out temp))
                        dy.Add(temp);
                }
                else
                {
                    // on odd line put in the dx list
                    if(double.TryParse(s, NumberStyles.Any, ci, out temp))
                        dx.Add(temp);
                }
                x++;                        
            }
        }
    }
