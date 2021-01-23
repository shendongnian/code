    namespace a
    {
        using type1 = int16;
        namespace b
        {
              using list1 = List<int16>
              namespace c
              {
                   var dictionary1 = Dictionary<type1, list1>
              }
        }
        using list1 = List<object>;
    }
