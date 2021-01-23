    SAPbobsCOM.SBObob obj = vCmp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoBridge);
            SAPbobsCOM.Recordset rs = vCmp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            rs = obj.GetBPList(SAPbobsCOM.BoCardTypes.cCustomer);
            rs.MoveFirst();
            int count = rs.RecordCount;
            grdBP.Rows.Clear();
            if (count > 0)
            {
                grdBP.Columns.Add("cardCode", "BP Code");
                grdBP.Columns.Add("cardName", "BP Name");
                grdBP.Columns.Add("cardType", "BP Type");
                grdBP.Rows.Add(count);
                int gridCounter = 0;
                while (!rs.EoF)
                {
                    DataGridViewRow row = grdBP.Rows[gridCounter];
                    row.Cells[0].Value = rs.Fields.Item("cardCode").Value;
                    row.Cells[1].Value = rs.Fields.Item("cardName").Value;
                    row.Cells[2].Value = rs.Fields.Item("cardType").Value;
                    gridCounter++;
                    rs.MoveNext();
                }
            }
