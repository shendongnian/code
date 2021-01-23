    var asm = Assembly.Load("path or assembly name");
    var enums = asm.GetTypes().Where(x => x.IsEnum).ToList();
    var result = enums
                .Select(
                    x =>
                        string.Format("{0},{1}", x.Name,
                            string.Join(",",Enum.GetNames(x)
                            .Select(e => string.Format("{0}={1}", e, (int)Enum.Parse(x, e))))));
    File.WriteAllLines("path", result);
