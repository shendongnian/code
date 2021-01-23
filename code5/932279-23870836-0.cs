           List<ContextParamValue> lst = db.ContextParamValues
            //.Include(x => x.ContextParam)
            .Where(pv => pv.ContextParam.Name.ToLower().Trim().Equals(pName.ToLower().Trim()))
            .Where(pv => pv.Value.Equals(pValue))
            .ToList<ContextParamValue>();
        rList.AddRange(lst);
