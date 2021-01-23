    {  
    oAtt.Lines.Add();  <------ here i think you have a error 
    oAtt.Lines.FileName = oAttNew.Lines.FileName;  
    oAtt.Lines.FileExtension = oAttNew.Lines.FileExtension;  
    oAtt.Lines.SourcePath = oAttNew.Lines.SourcePath;  
    oAtt.Lines.Override = BoYesNoEnum.tYES;  
    if (oAtt.Update() != 0)  
        throw new Exception(oCompany.GetLastErrorDescription());  
    }  
