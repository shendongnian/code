        [SitecoreType(TemplateId = "{7FC4F278-ADDA-4683-944C-554D0913CB33}", AutoMap = true)]
        public interface StubInterfaceAutoMapped
        {
            Guid Id { get; set; }
            Language Language { get; set; }
            string Path { get; set; }
            int Version { get; set; }
            string Name { get; set; }
            
            string StringField { get; set; }
        }
