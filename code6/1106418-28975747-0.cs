    private void button2_Click(object sender, EventArgs e)
      {
        string destination = textBox1.Text;
        string source = textBox2.Text;
    
        if (mapping.ContainsKey(source))
        {
            string directoryName = mapping[source];
            foreach (var f in Directory.GetFiles(directoryName))
            {
                File.Copy(f, Path.Combine(destination, Path.GetFileName(f)));
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        else
        {
            MessageBox.Show ("Oh No! Something went wrong, try again!");
        }
    }
