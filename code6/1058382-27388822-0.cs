            StringBuilder sb = new StringBuilder();
            sb.Append(@"<?xml version=""1.0"" encoding=""us-ascii"" ?>");
            sb.Append(@"<LoanSetupFile SchemaVersion=""3.0"" NumberOfLoans=""2"" xmlns=""https://www.something.com/schemas"">");
            sb.Append(@"<Loan ServicerLoanNumber=""1""/>");
            sb.Append(@"<Loan ServicerLoanNumber=""2""/>");
            sb.Append(@"</LoanSetupFile>");
            var doc = XDocument.Load(new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString() ?? "")));
            XNamespace ns = doc.Root.GetDefaultNamespace(); //This gives me the correct namespace
            var loans = from l in doc.Descendants(ns + "Loan") 
                        select new { ServicerLoanNumber = l.Attribute("ServicerLoanNumber").Value };
            // Temporarily display the values
            foreach (var l in loans)
            {
                MessageBox.Show(l.ServicerLoanNumber);
            }
