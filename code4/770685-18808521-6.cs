    StringBuilder output = new StringBuilder();
    for (int prov = 0; prov < census.GetLength(0); prov++)
    {
        StringBuilder sbTemp = new StringBuilder();
        for (int region = 0; region < census.GetLength(1); ++region)
        {
            if (census[prov, region] != 0)
            {
                sbTemp.AppendLine("  Region #" + region+1 + " " +
                    census[prov, region]);
            }
        }
        if (sbTemp.Length > 0)
        {
            // At least one region had population, so add that
            // and the province to the output.
            output.AppendLine("Province ID " + prov+1);
            output.Append(sbTemp);
        }
    }
