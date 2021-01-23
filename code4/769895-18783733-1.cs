        public partial class Form1 : Form
        {
    list<String> copy_of_form2_list;
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
    // for copy the object , we serialize and deserialize an object
                    try
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        FileStream output = new FileStream("temp", FileMode.OpenOrCreate, FileAccess.Write);
                        formatter.Serialize(output,f2.f2List);
                        output.Close();
                    }
                    catch
                    {
    
                    }
    
    
                    try
                    {
                        BinaryFormatter reader = new BinaryFormatter();
                        FileStream input = new FileStream("temp", FileMode.Open, FileAccess.Read);
                        fcopy_of_form2_list=((List <String>)reader.Deserialize(input));
                        input.Close();
    
                        if (File.Exists(@"temp"))
                        {
                            File.Delete(@"temp");
                        }
    
                    }
                    catch
                    {
                    }
                List<string> f1List = copy_of_form2_list;
            }
