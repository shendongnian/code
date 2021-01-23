    plainTextPasswordTextEdit = new RepositoryItemTextEdit();
    hiddenPasswordTextEdit = new RepositoryItemTextEdit()
    {
      PasswordChar = '*'
    };
    
    passwordColumn.ColumnEdit = hiddenPasswordTextEdit;
