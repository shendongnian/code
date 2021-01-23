            for (int i = 0; i < DT.Rows.Count; i++)
            {
                Promotes promotes = new Promotes();
                if (!Convert.IsDBNull(DT.Rows[i]["XPITEM"]))
                {
                    promotes.T_item = Convert.ToDecimal(DT.Rows[i]["XPITEM"]);
                }
                promotes.T_uniq = DT.Rows[i]["XPUNIQ"].ToString();
                promotes.T_desc = DT.Rows[i]["XPDSC2"].ToString();
                if (!Convert.IsDBNull(DT.Rows[i]["XPPPCP"]))
                {
                    promotes.T_Barcode = Convert.ToDecimal(DT.Rows[i]["XPPPCP"]);
                }
                list.Add(promotes);
            }
