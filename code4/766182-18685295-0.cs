     public class ExtendedGridCategoryAttribute : GridAttribute
     {
          public ExtendedGridCategoryAttribute(int level, char tabCharacter)
              : base(new string(tabCharacter, level))
          {
          }
     }
     [ExtendedGridCategory(2,'\t')]
     public string Foo { get; set; }
