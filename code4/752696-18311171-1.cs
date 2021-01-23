    [Flags]
    private enum MyEnum {
      None = 0, 
      Apple = 1,
      Orange = 2,
      Tomato = 4,
      Potato = 8,
      Melon = 16,
      Watermelon = 32,
      Berry = Melon | Watermelon, 
      Fruit = Apple | Orange,
      Vegetable = Potato | Tomato
    }
    private static class MyEnumExtensions { 
      public static Boolean IsFruit(this MyEnum value) {
        return (value & MyEnum.Fruit) == MyEnum.Fruit;
      }
    
      public static Boolean IsVegetable(this MyEnum value) {
        return (value & MyEnum.Vegetable) == MyEnum.Vegetable;
      }
    
      public static Boolean IsBerry(this MyEnum value) {
        return (value & MyEnum.Berry) == MyEnum.Berry;
      }
    }
    ...
    
    MyEnum data = ...
    
    if (data.IsBerry()) {
      MessageBox.Show("Berry");       
    } 
  
