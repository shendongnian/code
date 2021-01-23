        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path=listBox1.SelectedValue as string;
            // return the path of the item
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                var files=openFileDialog1.FileNames;
                var paths=openFileDialog1.SafeFileNames;
                var items=new List<Tuple<string, string>>();
                if (paths.Length!=files.Length) throw new IndexOutOfRangeException();
                for (int i=0; i<files.Length; i++)
                {
                    items.Add(
                        new Tuple<string, string>(files[i],paths[i])
                        );
                }
                listBox1.DataSource=items;
                listBox1.DisplayMember="Item1";
                listBox1.ValueMember="Item2";
            }
        }
