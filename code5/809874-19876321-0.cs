     //  Create your dataGrodView with the 18 columns using your designer.
            int col = 0;
            foreach (var segment in segments)
            {
                //Console.WriteLine(segment);
                //sepList.Add(segment);
                dataGridView1.Rows[whateverRow].Cells[col].Value = segment;
            }
