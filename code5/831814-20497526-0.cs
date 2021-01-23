    public class AttributeContainer
    {
        public Dictionary<string,int> MimeTypes { get; set; }
        public Dictionary<string,Domain> SharedToDomains { get; set; }
        public Dictionary<string,Domain> SharedFromDomains { get; set; }
        
        public int Published_DocsCount { get; set; }
        public int Public_ReadAccess { get; set; }
        public int Public_CommentAccess { get; set; }
        public int Public_WriteAccess { get; set; }
        public int Public_DocsCount { get; set; }
        public int PublicWithLink_ReadAccess { get; set; }
        public int PublicWithLink_CommentAccess { get; set; }
        public int PublicWithLink_WriteAccess { get; set; }
        public int PublicWithLink_DocsCount { get; set; }
        public int InternalCollaborators_CollaboratorsCount { get; set; }
        public int InternalCollaborators_Read { get; set; }
        public int InternalCollaborators_Comment { get; set; }
        public int InternalCollaborators_Write { get; set; }
        public int InternalCollaborators_DocsCount { get; set; }
        public int OutsideDomain_CollaboratorsCount { get; set; }
        public int OutsideDomain_Read { get; set; }
        public int OutsideDomain_Comment { get; set; }
        public int OutsideDomain_Write { get; set; }
        public int OutsideDomain_DocsCount { get; set; }
        public int Domain_ReadAccess { get; set; }
        public int Domain_CommentAccess { get; set; }
        public int Domain_WriteAccess { get; set; }
        public int Domain_DocsCount { get; set; }
        public int DomainWithLink_ReadAccess { get; set; }
        public int DomainWithLink_CommentAccess { get; set; }
        public int DomainWithLink_WriteAccess { get; set; }
        public int DomainWithLink_DocsCount { get; set; }
    }
    
    public class Domain 
    {
        public int Users { get; set; }
        public int Documents { get; set; }
    }
