    // using System.Runtime.Serialization.Formatters.Binary
    Stream stream = File.Open(filename, FileMode.Create,FileAccess.ReadWrite);
    BinaryFormatter format = new BinaryFormatter();
    format.Serialize(stream, textBox1.Text);
    stream.Close();
