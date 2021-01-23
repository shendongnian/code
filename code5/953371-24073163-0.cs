    Dictionary<string, uint> Converted =  noticeDictionary
        // Next steps converts to an IEnumerable<anonymoustype<string,uint>>
        .Select(kvp=> new { key = kvp.Key , val = (uint)kvp.Value})
        // Now that we have strongly typed data in enumerable form, get it back into a dictionary
        .ToDictionary(item=>item.Key,item=>item.Value);
