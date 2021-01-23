      public static string ToJson(this IEnumerable<MsgContract> lst) {
         foreach (var item in lst)
            string entry += item.ToJson();
    
         return entry;
      }
