    var input = new[] { 0, 1, 2, 3, 4, 5, 6, 7 };
    numbers.Slice(1, 4);    // { 1, 2, 3 }
    numbers.Slice(-3, -1);  // { 5, 6 }
    numbers.Slice(5);       // { 5, 6, 7 }
    numbers.Slice(end:-4);  // { 0, 1, 2, 3 }
