    object obj = System.Windows.Forms.Application.OpenForms[row.Cells[0].Value.ToString()];
    Type t = Type.GetType("myNamespace.PC_01, myAssembly");
    
    if (obj.GetType() == t)
    {
       ((dynamic)obj).accept();
    }
