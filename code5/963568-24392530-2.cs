    var a = Array.CreateInstance(typeof(string), new[] { 10 }, new[] { -10 });
    a.SetValue("test", -5);
    Console.WriteLine(a.GetValue(-5));
    Console.WriteLine(a.GetLowerBound(0));
    // yields:
    // test
    // -10
