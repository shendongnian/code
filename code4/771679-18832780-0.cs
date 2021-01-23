        class FormResult
        {
          public DialogResult dr {get; private set;}
          public string LastName {get; private set;}
          public string FirstName {get; private set;}
        }
        
        class MyForm : whatever
        {
          static public FormResult Exec(string parm1, string parm2)
    {
          var result = new FormResult();
          var me = new MyForm();
          me.parm1 = parm1;
          me.parm2 = parm2;
          result.dr = me.ShowDialog();
          if (result.dr == DialogResult.OK)
          {
            result.LastName = me.LastName;
            result.FirstName = me.FirstName;
          }
          me.Close(); // should use try/finally or using clause
          return result;
        }
    }
    
    ... rest of MyForm
