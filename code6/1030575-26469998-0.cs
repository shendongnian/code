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
          // magic based on CultureInfo.CurrentCulture and Context here 
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
        // magic based on CultureInfo.CurrentCulture and Context here 
        // should return something in form of "Field '{0}' should have the same value as '{1}."
        string format = ...;
        return string.Format(CultureInfo.CurrentCulture, format, name, OtherPropertyDisplayName);      
      }
    }
    
