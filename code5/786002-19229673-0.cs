    foreach (var item in res)
            {
                ResultsList rl = new ResultsList();
                if (item.gr != null)
                {
                    rl.Forename = item.f.Forename;
                    rl.Postcode = item.gr.postcode;
                    rl.ProductName = item.f.ProductName;
                }
                else
                {
                    rl.Forename = item.f.Forename;
                    rl.ProductName = item.f.ProductName;
                }
