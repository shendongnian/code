    public class CombinedKey {
      private enumA _enumAValue;
      private enumB _enumBValue;
    
      override Equals..
      override GetHashCode..
    
    }
    
    public class MainProgram {
       private Dictionary<CombinedKey,SomeValue> _combinedKey2Value = new Dictionary<CombinedKey,SomeValue);
    
       /// Populate this dictionary based on your Switch-case logic
     
       public bool TryGetValue(enumA enumAValue, enumB enumBValue, out SomeValue someValue){
              var combinedKey = new CombinedKey(enumAValue, enumBValue);
              return _combinedKey2Valye.TryGetValue(combinedKey, out someValue);
    
        }
    }
