    using System.ComponentModel.DataAnnotations;//I needed this for [Key] attribute on another property
    using System.ComponentModel.DataAnnotations.Schema;//this one is for [NotMapped]
    ...
    [ScriptIgnore]
    [NotMapped]
    public System.Timers.Timer Timer { get; set; }
