    for(int i = 0 ;i< xxxx; i++)
    {
    oAtt.Lines.setCurrentLine(i);
    if(i>0)
    {
    oAtt.Lines.add();
    }
    oAtt.Lines.FileName = oAttNew.Lines.FileName;  
    oAtt.Lines.FileExtension = oAttNew.Lines.FileExtension;  
    oAtt.Lines.SourcePath = oAttNew.Lines.SourcePath;  
    oAtt.Lines.Override = BoYesNoEnum.tYES; 
    }
    if (oAtt.Update() != 0)  
        throw new Exception(oCompany.GetLastErrorDescription()); 
