                object[] values = g.GetColumnValues(e.Row.DataItemIndex, "Firstname,Lastname,CompanyName");
                if (values != null)
                {
                    string header = Server.HtmlEncode(values[0] + " " + values[1] + " @ " + values[2]);
                }
                // do whatever you want with this value
