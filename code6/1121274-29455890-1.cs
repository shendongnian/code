        private void button4_Click(object sender, EventArgs e)
        {
            ObjectCollection items = null;
            switch (combobox1.Text) {
               case "ListBox1":
                    items = listBox1.Items;
               break;
               case "ListBox2":
                    items = listBox2.Items;
               break;
               default:
                   throw new Exception("no selection");
               break;
            }
            SaveFileDialog svl = new SaveFileDialog();
            svl = saveFileDialog1;
            svl.Filter = "txt files (*.txt)|*.txt";
            if (svl.ShowDialog() == DialogResult.OK)
            {
                using (FileStream S = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter st = new StreamWriter(S))
                    foreach (string a in items) //the selected objectcollection 
                        st.WriteLine(a.ToString());
            }
