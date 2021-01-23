    private static void CheckValue<T>(T temp,  T variable) where T : struct 
    {
       if (!new[] {typeof (bool), typeof (float), typeof (int)}.Contains(typeof (T)))
       {
              // invalid type
       }
       if (temp.Equals(variable))
       {
          EditorUtility.SetDirty(target);     
       }
    }
