    public class UniversalPrincipalQueryOptions
    {
        public Boolean IncludeProperties { get; private set; }
        public Boolean IncludeOrganizationUnits { get; private set; }
        public Boolean IncludeManagers { get; private set; }
    
        // UPDATED !!
        public static UniversalPrincipalQueryOptions OrganizationUnitsAndManagers
        {
            get
            {
                return new UniversalPrincipalQueryOptions { IncludeOrganizationUnits = true, IncludeProperties = true, IncludeManagers = true };
            }
        }
    
        // NEW!!
        public static UniversalPrincipalQueryOptions OrganizationUnits
        {
            get
            {
                return new UniversalPrincipalQueryOptions { IncludeOrganizationUnits = true, IncludeProperties = true};
            }
        }
    
        public static UniversalPrincipalQueryOptions None
        {
            get
            {
                return new UniversalPrincipalQueryOptions { IncludeProperties = false };
            }
        }
    
        private UniversalPrincipalQueryOptions()
        {
            this.IncludeProperties = true;
        }
    }
 
