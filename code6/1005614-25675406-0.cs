    public static bool IsNullOrEmpty(object obj) {
      IList list = obj as IList;
      if (list != null) {
        return list.Count == 0;
      }
      IEnumerable e = obj as IEnumerable;
      if (e != null) {
        return !e.GetEnumerator().MoveNext();
      }
      return false;
    }
