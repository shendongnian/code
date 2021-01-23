    List<object> result = new List<object>();
            var MyList = new List<Object>{
                                    523,
                                    2.555,
                                    null,
                                    "ExampleValue1",
                                    "ExampleValue2",
                                };
            MyList.ForEach(x =>
            {
                if (x != null)
                {
                    if (!string.IsNullOrEmpty(Regex.Replace(x.ToString(), @"^[0-9]*(?:\.[0-9]*)?$", string.Empty)))
                    {
                        result.Add(x);
                    }
                }
            });
