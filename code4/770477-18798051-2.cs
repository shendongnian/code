    StringBuilder sb = new StringBuilder();
    foreach(Item i in Enum.GetValues(typeof(Item))) 
        if ((valueFromSQL & ((int)i)) != 0) {
            if (sb.Length > 0)
                sb.Append(", ");
            sb.Append(i);
        }
    string result = sb.ToString();
