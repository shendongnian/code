    string p = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                      "<W-TIBCPTRs>" +
                        "<W-TIBCPTR>" +
                          "<TYPTRT>FDR2 R</TYPTRT>" +
                          "<CLAFCNO VALIDE=\"NON\">5b1</CLAFCNO>" +
                          "<NUMCLI>0067781</NUMCLI>" +
                          "<TYPACT>D</TYPACT>" +
                        "</W-TIBCPTR>" +
                        "<W-TIBCPTR>" +
                          "<TYPTRT>FDR2 R</TYPTRT>" +
                          "<CLAFCNO>511</CLAFCNO>" +
                          "<NUMCLI>0068078</NUMCLI>" +
                          "<TYPACT>D</TYPACT>" +
                        "</W-TIBCPTR>" +
                      "</W-TIBCPTRs>";
          XDocument doc = XDocument.Load(p);
    
          var sb = new System.Text.StringBuilder();
          foreach (var o in doc.Descendants("W-TIBCPTR"))
          {
            var TYPTRT = o.Element("TYPTRT").Value;
            var CLAFCNO = o.Element("CLAFCNO").Value;
            var NUMCLI = o.Element("NUMCLI").Value;
            var TYPACT = o.Element("NUMCLI").Value;
            sb.AppendLine(string.Format("{0},{1},{2},{3}", TYPTRT, CLAFCNO, NUMCLI, TYPACT));
          }
