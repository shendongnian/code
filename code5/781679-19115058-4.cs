    ILArray<int> C = 1;
    ILArray<int> R = ILMath.find(L, 0, C); 
    // C now holds the column indices, R the row indices
    for (int i = 0; i < C.Length; i++) {
        System.Diagnostics.Debug.WriteLine("({0},{1})", R.GetValue(i), C.GetValue(i)); 
    }
