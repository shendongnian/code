    public class IngredientGraphTransformer : IResultTransformer
    {
       public static IngredientGraphTransformer Create()
       {
          return new IngredientGraphTransformer();
       }
    
       IngredientGraphTransformer()
       {
       }
    
       public IList TransformList(IList collection)
       {
          return collection;
       }
    
       public object TransformTuple(object[] tuple, string[] aliases)
       {
          Guid ingId = (Guid)tuple[0];
          Guid recipeId = (Guid)tuple[1];
          Single? qty = (Single?)tuple[2];
          Units usageUnit = (Units)tuple[3];
          UnitType convType = (UnitType)tuple[4];
          Int32 unitWeight = (int)tuple[5];
          Units rawUnit = Unit.GetDefaultUnitType(convType);
          // Do a bunch of logic based on the data above
    
          return new IngredientBinding
          {
             RecipeId = recipeId,
             IngredientId = ingId,
             Qty = qty,
             Unit = rawUnit
          };
       }
    }
