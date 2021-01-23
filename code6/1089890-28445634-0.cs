    for(int i = 1; i < 170; ++i)
    {
     String tempName1 = "list" + i;
     List<ulong> temp1 = (List<ulong>)typeof(this).GetProperty(tempName1).GetValue(this, null);
     if (masterList.Any(x => temp1.Contains(x))
     {
      String tempName2 = "CheckBox" + i;
      CheckBox temp2 = (CheckBox)typeof(this).GetProperty(tempName2).GetValue(this, null);
      temp2.IsPressed = true;
     }
    }
