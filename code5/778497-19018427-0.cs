            foreach (var p in parameters)
            {
                if (p.GetType().IsGenericType && p is IEnumerable)
                {
                    JArray l = new JArray();
                    foreach (var i in (IEnumerable)p)
                    {
                        l.Add(i);
                    }
                    props.Add(l);
                }
                else
                {
                    props.Add(p);
                }
            }
