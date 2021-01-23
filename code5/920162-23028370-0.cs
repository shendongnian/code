        string[] xInBGraph = { "IVR", "Agents", "Abandoned", "Cancelled" };
        List<string[]> final = new List<string[]>();
        for (int i = 0; i < xInBGraph.Count(); i++)
        {
            List<string> array = new List<string>();
            for (int x = 0; x < xInBGraph.Count(); x++)
            {
                if (x == i)
                {
                    array.Add(xInBGraph[i].ToString() + "=" + x);
                }
                else
                {
                    array.Add("0");
                }
            }
            final.Add(array.ToArray());
        }
        string json = JsonConvert.SerializeObject(final, Formatting.Indented);
