    StringBuilder sb = new StringBuilder();
    command.Parameters.Cast<DbParameter>()
                      .ToList()
                      .ForEach(p => sb.Append(
                                       string.Format("{0} = {1}{2}",
                                          p.ParameterName,
                                          p.Value,
                                          Environment.NewLine)));
    Console.WriteLine(sb.ToString());
