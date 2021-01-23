    var asm = Assembly.LoadFrom("path of the assembly");
    var enums = asm.GetTypes().Where(x => x.IsEnum).ToList();
    var result = enums
                .Select(
                    x =>
                        string.Format("{0},{1}", x.Name,
                            string.Join(",",Enum.GetNames(x)
                            .Select(e => string.Format("{0}={1}", e, (int)Enum.Parse(x, e))))));
    File.WriteAllLines("path", result);
