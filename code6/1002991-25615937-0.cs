            Dictionary<string, string> lnksValues = new Dictionary<string, string>();
            foreach (Link lnk in driver.Links)
            {
                if (!string.IsNullOrEmpty(lnk.Id))
                {
                    if (lnk.Id.Contains('_'))
                    {
                        lnksValues.Add(lnk.Id.Split('_')[1], lnk.Text);
                    }
                }
            }
