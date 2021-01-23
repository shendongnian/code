    private void Paste(DataGridView d)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.StringFormat))
            {
                string[] pastedRows = Regex.Split(o.GetData(DataFormats.StringFormat).ToString().TrimEnd("\r\n".ToCharArray()), "\r");
                int j = 0;
                try { j = d.CurrentRow.Index; } catch { }
                foreach (string pastedRow in pastedRows)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.CreateCells(d, pastedRow.Split(new char[] { '\t' }));
                    d.Rows.Insert(j, r);
                    j++;
                }
            }
        }
