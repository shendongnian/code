    try
            {
                if (!File.Exists(termfilelocation))
                {
                    throw new FileNotFoundException();
                }
                else
                {
                    StreamReader reader = new StreamReader(termfilelocation);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("File containing the questions not found");
                // this will display a message box sying whats in ("")
                OpenFileDialog OFD = new OpenFileDialog();   
                // this will create a new open file dialog box
                OFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                // this will filter out any file that isnt a text file
                DialogResult = OFD.ShowDialog();
                
                String result = OFD.FileName;
                 // this will give the result to be the file name 
                 // that was choosen in the open file dialog box 
                StreamReader reader = new StreamReader(result);
                termfilelocation = result;
            } 
