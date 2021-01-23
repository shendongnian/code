     public void OpenExistDoc(string docName)
        {
            object fileName = docName;
            object oMissing = Type.Missing;
            this.Application.Documents.Open(ref fileName, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing
                , oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
        }
 
     private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.OpenExistDoc("your file");
        }
