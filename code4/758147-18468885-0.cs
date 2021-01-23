    private void button4_Click(object sender, EventArgs e)
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter("C:\\XXX\\XXX\\XXX\\test2.html");
                String line;
                using (System.IO.StreamReader reader = new System.IO.StreamReader("C:\\XXX\\XXX\\XXX\\test.html"))
                {
                    //Do until the end
                    while ((line = reader.ReadLine()) != null) {
                    //You can insert extra logic here if you need to omit lines or change them
                    writer.WriteLine(line);
                    }
                    //All done, close the reader
                    reader.Close();
                }
                //Flush and close the writer
                writer.Flush();
                writer.Close();
    
            }
