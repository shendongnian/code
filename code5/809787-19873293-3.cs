			string[] lines = File.ReadAllLines("SalesNumbers.txt");
			foreach (string line in lines) {
				string[] s = line.Split("$".ToCharArray());
                if (s.Length<2) { /* */ }
				double d;
				if (!double.TryParse(s[1], NumberStyles.Float, CultureInfo.CurrentCulture, out d)) {				
                    // Handle if not a number
                }
				lstNames.Items.Add(s[0]);
                lstTotalSales.Items.Add(d);
			}
