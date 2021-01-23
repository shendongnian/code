        foreach (task_cases item in cases)
                {
                    //sb.Append("<tr>");
                    var idx = 0;
                    bool even = idx % 2 == 0;
                    if (even)
                        {
                        sb.Append("<tr background-color:#eee;>");
                        }
                    else
                        {
                        sb.Append("<tr background-color:#fff;>");
                        }
