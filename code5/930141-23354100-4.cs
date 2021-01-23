    using System.IO;
    using System.Xml.Serialization;
    ...
    ...
            LoanData loan = new LoanData();
            loan.LoanID = "9980001140";
            loan.LoanAmount = 150000;
            BORROWER borrower = new BORROWER();
            borrower.FullName = "Johnny Smoth";
            loan.BORROWERS = new BORROWERS();
            loan.BORROWERS.BORROWER = new BORROWER();
            loan.BORROWERS.BORROWER = borrower;
            TextWriter writer = new StreamWriter("C:\\Test\\LoanData.xml");
            XmlSerializer ser = new XmlSerializer(typeof(LoanData));
            ser.Serialize(writer, loan);
            writer.Close();
