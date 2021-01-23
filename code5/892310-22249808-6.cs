    for (int i = 0; i < sTransactionEnquiryDB.Rows.Count; ++i)
                    {
                        double d = 0;
                        Double.TryParse(sTransactionEnquiryDB.Rows[i].Cells[14].Text, out d);
                        sum += d;
                    }
