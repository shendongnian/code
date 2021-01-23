      private void button4_Click(object sender, EventArgs e)
            {
                String line;
                String filetext = null;
                int count = 0;
                using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\XXXX\\XXXX\\XXXX\\test.html"))
                {
                  while ((line = reader.ReadLine()) != null) { 
                    if (count == 0) {
                        //No newline since its start
                        if (line.StartsWith("<")) {
                            //skip this it is formatted stuff
                        }
                        else {
                        filetext = filetext + line; 
                        }
                        }
                    else {
                        if (line.StartsWith("<"))
                        {
                            //skip this it is formatted stuff
                        }
                        else
                        {
                            filetext = filetext + "\n" + line;
                        }
                    }
                    count++;                           
               }                
                Trace.WriteLine(filetext);                  
                reader.Close();
                }          
            }
