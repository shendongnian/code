    StringBuilder output = new StringBuilder();
    for (int prov = 0; prov < census.GetLength(0); prov++)
    {
        output.AppendLine("Province ID " + prov+1);
        for (int region = 0; region < census.GetLength(1); ++region)
        {
            output.AppendLine("  Region #" + region+1 + " " +
                census[prov, region]);
        }
    }
