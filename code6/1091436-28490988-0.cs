            var tempOutputList = new List<string>();
            for (var c = -40; c <= 40; c++)
            {
                // Celsius convert to Fahrenheit//
                var f = 9.0 / 5.0 * c + 32;
                var tempOutputText = "Celsius = " + c.ToString("n3") + " " + "Fahrenheit = " + f.ToString("n3");
                tempOutputList.Add(tempOutputText);
                tempListBox.Items.Add(tempOutputText);
            }
            
            using (var file = new StreamWriter(@"C:\tempFile.txt"))
            {
                foreach (string tempOutput in tempOutputList)
                {
                    file.WriteLine(tempOutput);
                }
            }
