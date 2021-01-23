    public class MyModelBinderAttribute : CustomModelBinderAttribute
    {
         public override IModelBinder GetBinder()
         {
              return new MyModelBinder();
         }
    }
