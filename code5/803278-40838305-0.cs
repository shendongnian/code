    void Rotate<T>(T[] array, int offset) {
      if (offset==0) return;
      if (offset>0) {
        var temp = new T[offset];
        System.Array.Copy(array, array.Length-offset, temp, 0, offset);
        System.Array.Copy(array, 0, array, offset, array.Length-offset);
        System.Array.Copy(temp, 0, array, 0, offset);
      }else{
        var temp = new T[-offset];
        System.Array.Copy(array, 0, temp, 0, -offset);
        System.Array.Copy(array, -offset, array, 0, array.Length+offset);
        System.Array.Copy(temp, 0, array, array.Length+offset, -offset);
      }
    }
