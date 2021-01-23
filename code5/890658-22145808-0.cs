    public class DocumentTypeViewModel
    {
         ModuleRepository _modulerepository = new ModuleRepository();
         public tbl_DocumentTypes Document { get; private set; }
         public IEnumerable<SelectListItem> Modules { get; private set; }
    
         public DocumentTypeViewModel(tbl_DocumentTypes document)
         {
              Document = document;
              //var _modules = _modulerepository.FindAllModules().Select(d => new  {Module_Id= SqlFunctions.StringConvert((double?)d.Module_Id), Text = d.ModuleName });
              Modules = _modulerepository.FindAllModules()
                        .Select(d => new SelectListItem
                                     { 
                                        Value= SqlFunctions.StringConvert((double?)d.Module_Id), 
                                        Text = d.ModuleName 
                                     });          
          }
    }
