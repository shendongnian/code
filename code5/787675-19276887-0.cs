    bool readOnly = true;
    Object templatePath = @"Path";
    Object oMissing = System.Reflection.Missing.Value;
    Word.Application wordApp = new Word.Application();
    Word.Document wordDoc = wordApp.Documents.Open(templatePath, oMissing, readOnly, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
