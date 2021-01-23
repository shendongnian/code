    Assert.IsTrue(ComareDataTables(DTable1,DTable2));
    private bool CompareDataTables(DataTable DT1, DataTable DT2)
        {
            if ((DT1 == null) && (DT2 == null))
                return true;
            else if ((DT1 != null) && (DT2 != null))
            {
                if (DT1.Rows.Count == DT2.Rows.Count)
                {
                    if (DT1.Columns.Count == DT2.Columns.Count)
                    {
                        for (int i = 0; i < DT1.Rows.Count; i++)
                        {
                            for(int j = 0; j<DT1.Columns.Count; j++)
                            {
                                if (DT1.Rows[i][j].ToString() != DT2.Rows[i][j].ToString())
                                    return false;
                            }
                        }
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
