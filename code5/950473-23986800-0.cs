    // illogical for SSIS
    for(int i = 0; i < fileAIndex; i++)
        Dts.Variables["ObjectVariableA"] += fileA[i].toString();
    // Replaced with
    Dts.Variables["ObjectVariableA"].Value = fileA;
