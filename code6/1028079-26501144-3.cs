    private void print_Click(object sender, EventArgs e)
    {
        string filePath = image_print();
        
        StreamReader test2 = new StreamReader(filePath);
        string s = test2.ReadToEnd();
        test2.Close();
        
        s += Print_image();
        PrintFactory.sendTextToLPT1(s);
        System.IO.File.Delete(filePath); //Now delete the file which you have copied in image_print() method.
    }
