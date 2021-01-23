            if (listSubjects.Items.Count > 0)
            {
                for (int i = 0; i < listSubjects.Items.Count; i++)
                {
                    if (listSubjects.GetItemChecked(i))
                    {
                        DataRowView castedItem = listSubjects.Items[i] as DataRowView;
                        string item = Convert.ToString(castedItem["SubjectName"]);
                        dgvEnterMarks.Columns.Add(item, item);
                    }
                }
                PopulateGridView();
            }
