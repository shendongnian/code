            if (item is string[])
            {   
                IEnumerable<string> list = item as IEnumerable<string>;
                return String.Format("\"{0}\"", String.Join(",", list).Replace("\"", "\""));
            }
