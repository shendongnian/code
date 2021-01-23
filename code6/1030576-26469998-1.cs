    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event)]
    public sealed class LocalizedDisplayNameAttribute : DisplayNameAttribute {
      public LocalizedDisplayNameAttribute() {
      }
      public LocalizedDisplayNameAttribute(object context) {
        Context = context;
      }
      public object Context { get; set; }
      public override string DisplayName {
        get {
          // TODO: override based on CultureInfo.CurrentCulture and Context here 
          return "LocalizedAttributeName";
        }
      }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class LocalizedCompareAttribute : CompareAttribute {
    
      public object Context { get; set; }
      public LocalizedCompareAttribute(string otherProperty)
        : base(otherProperty) {
      }
      public override string FormatErrorMessage(string name) {
        // TODO: override based on CultureInfo.CurrentCulture and Context here 
        string format = "Field '{0}' should have the same value as '{1}'.";
        return string.Format(CultureInfo.CurrentCulture, format, name, OtherPropertyDisplayName);      
      }
    }
    
