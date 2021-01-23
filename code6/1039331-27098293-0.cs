     private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "SAVE";      
            var files = Directory.GetFiles(@"C:\\Users\\Apple\\Desktop\\proj").Length;
            string fileName = textBox1.Text.Substring(0, 3) + -+ ++files + ".txt";
            string path2 = Path.GetFullPath("C:\\Users\\Apple\\Desktop\\proj");
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string var = Path.Combine(docPath, path2);
            string var1 = Path.Combine(var, fileName);
            using (StreamWriter writer = new StreamWriter(var1))
            {
                string var6 = textBox1.Text;
                string var7 = "                 ";
                string var8 = textBox2.Text;
                string var9 = string.Concat(var6, var7, var8);
                writer.WriteLine(var9);
            }
            MessageBox.Show("File created");
}
        
