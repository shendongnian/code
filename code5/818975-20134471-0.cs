    var serializer = new XmlSerializer(typeof(List<Bill>));
    
    using(var reader = new StreamReader("YourFileNameHere.xml"))
    {
         try
         {
            source.DataSource = (List<Bill>)serializer.Deserialize(reader);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
    }
    comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
    comboBox1.DataSource = source;
    //"Date" is the name of the property in your Bill object
    //representing the date.
    comboBox1.DisplayMember = "Date";
