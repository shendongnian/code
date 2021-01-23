    Testing test = new Testing((x, y) => x + y);
    // or
    Testing test = new Testing();
    test.Calc = (x, y) => x + y;
    // then
    test.Calc(2, 3); // 5
    test.CalcWithOne(7); // 8
