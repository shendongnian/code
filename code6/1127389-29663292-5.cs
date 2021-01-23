     private Animal[] ReadFile(string filename)
     {
            BinSerializerUtility BinSerial = new BinSerializerUtility();
            var animals = BinSerial.BinaryFileDeSerialize<Animal>(filename);
            return animals.ToArray();
     }
     private void mnuFileOpen_Click(object sender, EventArgs e)
     {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
          string thefilename = openFileDialog1.FileName;
          var messages = ReadFile(thefilename);
          if (messages != null)
          {
              messages.ToList().ForEach(msg => 
                    Resultlst.Items.Add(msg));
          }
          else
          {
             UpdateResults();
          }
       }
    }
