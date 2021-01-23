        private void textboxInput_TextChanged(object sender, EventArgs e)
        {
            List<String> temp = new List<string>();
            for (int i = 0; i < fullList.Capacity - 1; i++ )
            {
                if (fullList[i].Contains(textboxInput.Text))
                    temp.Add(ls[i]);
            }
            listboxOutput.DataSource = temp;
        }
