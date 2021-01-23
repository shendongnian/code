            public void Load(string fileName)
        {
            FileStream fs2 = new FileStream(fileName, FileMode.Open);
            BinaryFormatter binformat = new BinaryFormatter();
            if (fs2.Length == 0)
            {
                MessageBox.Show("List is empty");
            }
            else
            {
                LoadedList = (List<Object>)binformat.Deserialize(fs2);
                fs2.Close();
                List.Clear();
                MessageBox.Show(Convert.ToString(LoadedList));
                List.AddRange(LoadedList);
            }
