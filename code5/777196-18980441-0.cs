            var s = new StringBuilder();
            s.AppendFormat("\"{0}\",\"{1}",
                                "test1",
                                "test2"
                                         );
            for (var i = 2; i < 10; i++)
            {
                s.AppendFormat(",\"{0}\"", "loop"); 
            }
