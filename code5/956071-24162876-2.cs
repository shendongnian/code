    PageOneCache pageOneCache = new PageOneCache(){ flag1 = true, ages = new List<int>(){1,3,4}, boxes = 2};
    
    if(EZ_iso.IsolatedStorageAccess.FileExists("pageOneCache")
       Ez_iso.IsolatedStorageAccess.OverwriteFile("pageOneCache",pageOneCache);
    else
       Ez_iso.IsolatedStorageAccess.SaveFile("pageOneCache",pageOneCache);
    
