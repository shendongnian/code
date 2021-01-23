    public enum SomeTypes {
        SomeType1 = 1,
        SomeType2 = 2,
        SomeType3 = 3
    }
    public class SomeClass
    {
        public SomeTypes SomeType { get; set; }
    
        bool validEnum() {
            return System.Enum.IsDefined(typeof(SomeTypes), this.SomeType);
        }
    }
