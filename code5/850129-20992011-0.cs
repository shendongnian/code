    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    List<string> ncmFile = new List<string>();
    ncmFile.Add("NCM1");
    ncmFile.Add("NCM2");
    
    List<string> naeFile = new List<string>();
    naeFile.Add("NAE1");
    naeFile.Add("NAE2");
    
    Parallel.For(0, ncmFile.Count, (i) =>
    {
        string ncm = ncmFile[i];
        string nae = naeFile[i];
        NCMNAEConversion(ncm, nae);
    });
