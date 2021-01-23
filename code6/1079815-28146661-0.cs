    /// <summary>
    /// Validation rules for the <see cref="Test"/> object
    /// </summary>
    /// <remarks>
    /// 2015-01-26: Created
    /// </remarks>
    [MetadataType(typeof(TestValidation))]
    public partial class Test { }
    public class TestValidation
    {
        /// <summary>Name is required</summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        /// <summary>Text is multiline</summary>
        [DataType(DataType.MultilineText)]
        [AllowHtml]
        public string Text { get; set; }
    }
