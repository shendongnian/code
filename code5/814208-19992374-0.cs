    var fastAllocate =
                typeof (string).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
                    .First(x => x.Name == "FastAllocateString");
    var newString = (string)fastAllocate.Invoke(null, new object[] {20});
    Console.WriteLine(newString.Length); // 20
