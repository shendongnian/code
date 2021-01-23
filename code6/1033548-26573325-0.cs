    const int N = 1000;
    //Add every multiple of 3 to the list
    for (int x = 3; x < N; x += 3) {
         list.Add(x); 
    }
    //Add every multiple of 5 to the list
    for (int y = 5; y < N; y += 5) {
        list.Add(y);
    }
    int sum = list.Sum();
