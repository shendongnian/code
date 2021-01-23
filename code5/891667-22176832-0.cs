     var fileContents = System.IO.File.ReadAllLines(textBox5.Text);
                var outFileContents = new List<string>();
                foreach (var line in fileContents)
                {
        
                   
        
                   
                }
         System.IO.File.WriteAllLines(textBox6.Text, outFileContents);
        
        
                Process.Start(textBox6.Text);
        
            }
