            int ColumnCount = dgv.Columns.Count;
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                DataRow dataRow = dt.NewRow();
                for (int i = 0; i < ColumnCount; i++)
                {
                    dataRow[i] = dr.Cells[i];
                }
                // #1 Add this code.
                dt.Rows.Add(dataRow);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            XmlTextWriter newXml = new XmlTextWriter(@"c:/older/DGVXML.xml", Encoding.UTF8);
            // #2 Change method.
            //ds.WriteXmlSchema(newXml);
            ds.WriteXml(newXml);
