            this.InvokeEx(x => x.dataGridView1.ColumnCount = columnHeader.Split(';').Count<string>());
            List<string> AllLinesFromAllFilesToListTrimmedSorted = new ReadAllLinesFromFilesInDirectory("StudentList", "IT102-Cplus-Section", "StudentID").SortedJoinedTrimmedAllLinesToList();
            
            this.InvokeEx(x => x.toolStripProgressBar1.Value = 0);
            this.InvokeEx(x => x.toolStripProgressBar1.Maximum = AllLinesFromAllFilesToListTrimmedSorted.Count());
            foreach (string singleLine in AllLinesFromAllFilesToListTrimmedSorted)
            {
                this.InvokeEx(x => x.toolStripProgressBar1.Value++);
                this.InvokeEx(x => x.toolStripStatusLabel1.Text = x.toolStripProgressBar1.Value.ToString());
                this.InvokeEx(x => x.dataGridView1.Rows.Add(singleLine.Split(';')));
                this.InvokeEx(x => x.listBox1.Items.Add("Processed Line: " + singleLine));
            }
