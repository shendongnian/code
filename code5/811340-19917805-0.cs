    List<string> _errors;
    
    void init()
    {
     _errors = new List<string>();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
      init();
    }
    
    btnTest_Click(object sender, EventArgs e)
    {
        ...
        var result = myFunc(...);
        if (result)
        {...}
        else
        {
            if (_errors.Count > 0)
            {
              var sb = new StringBuilder("<ul>");
              foreach (string err in _errors)
              {
                sb.AppendLine(string.Format("<li>{0}</li>", err));
              }
              sb.AppendLine("</ul>");
              lblStatus.Text=sb.ToString();//Make this a Literal
            }
        }
    }
    
    private bool myFunc(...)
    {
        var result = true;
        try
        {
            ...
            ...        
        }
        catch (Exception ex)
        {
            result = false;
            _errors.Add(ex.Message);
        }
        return result;
    }
