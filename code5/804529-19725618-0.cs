    if (item.CalcInsor_Desc != null)
    {
        string[] CalcInsor_Desc = item.CalcInsor_Desc.ToString().Split('.');
            if (CalcInsor_Desc.Length >= 2)
            {
                 schema2.CalcInsonorisation_TypeCode = CalcInsor_Desc[0];
                 schema2.CalcInsonorisation_Desc = CalcInsor_Desc[1];
            }
    }
