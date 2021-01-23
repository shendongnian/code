    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(LogonMetaData))]
    public partial class FirstViewModel
    {
        public string LogonID { get; set; }
        public string Password { get; set; }
    }
    using System.ComponentModel.DataAnnotations;
    [MetadataType(typeof(LogonMetaData))]
    public partial class SecondViewModel
    {
        public string LogonID { get; set; }
        public string Password { get; set; }
    }
