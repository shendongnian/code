    ISomeType child;
    if (radioSomeType.Checked)
    {
        child = new SomeType();
    }
    else if(radioSomeOTherType.Checked)
    {
        child = new SomeOTherType();
    }
    child.MdiParent = parent;
    child.Open();
