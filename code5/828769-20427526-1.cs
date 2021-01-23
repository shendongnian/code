    using (var rs = cmd.ExecuteResultSet())
    {
        var fieldCount = rs.fieldCount;
        var values = new Object[rs.FieldCount];
        // cache your ordinals here using rs.GetOrdinal(fieldname)
        var ID_ORDINAL = rs.GetOrdinal("Id");
        // etc
        while(rs.Read())
        {
            rs.GetValues(values);
            var invItem = new HHSUtils.InventoryItem
            {
                Id = (string)values[ID_ORDINAL],
                PackSize = (short)values[PACK_SIZE_ORDINAL],
                // etc
            };
            invItems.Add(invItem);
        }
    }
