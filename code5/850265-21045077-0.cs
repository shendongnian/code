    public class SpecialDays : List<SpecialDay>
    {
        public SpecialDays()
        {
            if(DesignerProperties.IsInDesignTool)
                return;
    
            DeviceManagementDomainContext domainContext = new DeviceManagementDomainContext();
    
            var query = domainContext.GetSpecialDaysForEditorQuery();
            LoadOperation<SpecialDay> operation = domainContext.Load(query);
            operation.Completed += (s, e) =>
            {
                if (operation.HasError)
                {
                    if (operation.Error != null)
                    {
                        operation.MarkErrorAsHandled();
                    }
                    this.AddRange(new List<SpecialDay>());
                }
                else
                {
                    List<SpecialDay> specialDays = operation.Entities.ToList();
                    this.AddRange(specialDays);
    
                }
            };
        }
    } 
