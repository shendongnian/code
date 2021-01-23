    //Use this extension method for convenience
    public static class CheckBoxExtension {
      public static void SetChecked(this CheckBox chBox, bool check){
        typeof(CheckBox).GetField("checkState", BindingFlags.NonPublic |
                                                BindingFlags.Instance)
                        .SetValue(chBox, check ? CheckState.Checked : 
                                                 CheckState.Unchecked);
        chBox.Invalidate();
      }
    }
    //then you can use the SetChecked method like this:
    checkBox1.SetChecked(true);//instead of checkBox1.Checked = true;
    checkBox1.SetChecked(false);//instead of checkBox1.Checked = false;
