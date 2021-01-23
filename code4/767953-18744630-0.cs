    private void First()
    {
        using (WinEntitie obj = new WinEntitie())
        {
            var FirstValue = (from a in obj.Employees select a.EmpName).Take(1);
        }
    }
    private void Sec()
    {
        using (WinEntitie obj = new WinEntitie())
        {
            var FirstValue = (from a in obj.Employees orderby a.EmpID ascending select a.EmpName ).Skip(1).First();
        }
    }
