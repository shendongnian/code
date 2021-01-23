    for (int i = 0; i < sTransactionEnquiryDB.Rows.Count; ++i)
                {
                    double d = 0;
                    Double.TryParse(sTransactionEnquiryDB.Rows[i].Cells[15].Value.ToString(), out d);
                    sum += d;
                }
