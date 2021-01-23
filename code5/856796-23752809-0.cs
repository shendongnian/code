    [XmlRoot(ElementName = "ns0:Response",)]
        public class Root
        {
            [XmlElement(ElementName = "ns0:Response")]
            public nsResponse _nsResponse { get; set; }  
        }
    
        public class nsResponse
        {
            [XmlElement(ElementName = "GenericContents")]
            public GenericContents _GenericContents { get; set; } 
        }
    
        public class GenericContents
        {
            private string moduleIdField;
    
            private string titleField;
    
            private string descriptionField;
    
            private string buildingIdField;
    
            private string geoCoordinateXField;
    
            private string geoCoordinateYField;
    
            public string ModuleId
            {
                get
                {
                    return (!string.IsNullOrEmpty(moduleIdField)) ? moduleIdField.ToString() : "";
                }
                set
                {
                    this.moduleIdField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
    
            /// <remarks/>
            public string Title
            {
                get
                {
                    return (!string.IsNullOrEmpty(titleField)) ? titleField.ToString() : "";
                }
                set
                {
                    this.titleField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
    
            /// <remarks/>
            public string Description
            {
                get
                {
                    return (!string.IsNullOrEmpty(descriptionField)) ? descriptionField.ToString() : "";
                }
                set
                {
                    this.descriptionField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
    
            /// <remarks/>
            public string BuildingId
            {
                get
                {
                    return (!string.IsNullOrEmpty(buildingIdField)) ? buildingIdField.ToString() : "";
                }
                set
                {
                    this.buildingIdField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
    
            /// <remarks/>
            public string GeoCoordinateX
            {
                get
                {
                    return (!string.IsNullOrEmpty(geoCoordinateXField)) ? geoCoordinateXField.ToString() : "";
                }
                set
                {
                    this.geoCoordinateXField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
    
            /// <remarks/>
            public string GeoCoordinateY
            {
                get
                {
                    return (!string.IsNullOrEmpty(geoCoordinateYField)) ? geoCoordinateYField.ToString() : "";
                }
                set
                {
                    this.geoCoordinateYField = !string.IsNullOrEmpty(value) ? (value).ToString() : "";
                }
            }
        }
