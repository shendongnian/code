        cb.BeginText();
        string textLine = Convert.ToDouble(dr["PaymentAmount"]).ToString("C");
        textLine += "    Copay Paid1: " + Convert.ToDecimal(dr["CopayAmount"]).ToString("C");
        cb.EndText(); // Added this
        cb.BeginText();
        string s = "";
        s = "Total Paid 2:";
        cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, s, 75, 595, 0);
        cb.EndText();
        cb.BeginText();
        string textLine = Convert.ToDouble(dr["PaymentAmount"]).ToString("C");
        textLine += "    Copay Paid2: " + Convert.ToDecimal(dr["CopayAmount"]).ToString("C");
        cb.EndText(); // Added this
