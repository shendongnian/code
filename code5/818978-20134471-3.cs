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
    SecondSource.DataSource = source;
    comboBox1.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
    comboBox2.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            
    comboBox1.DisplayMember = "Date";
    comboBox2.DisplayMember = "Date";
    comboBox1.DataSource = source;
    comboBox2.DataSource = SecondSource;
