            List<string> names = new List<string>();
            List<double> values = new List<double>();
			string[] lines = File.ReadAllLines("SalesNumbers.txt");
			foreach (string line in lines) {
				string[] s=line.Split("$".ToCharArray());
				names.Add(s[0]);
				double d;
				if (double.TryParse(s[1], NumberStyles.Float, CultureInfo.CurrentCulture, out d)) {
					values.Add(d);
				}
                else {
                    // Handle if not a number
                }
			}
