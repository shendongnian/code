    [Code]
    procedure InstallSql;
    
    var
      ResultCode: Integer;
      StatusText: string;
    begin
      StatusText := WizardForm.StatusLabel.Caption;
      WizardForm.StatusLabel.Caption := 'Installing Microsoft SQL Local Database...';
    
       if not ShellExec('',ExpandConstant('{tmp}\SqlLocalDB.MSI'), '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode) then
         begin
        MsgBox('SQL local DB failed with code: ' + IntToStr(ResultCode) + '.',
          mbError, MB_OK);
        WizardForm.StatusLabel.Caption := StatusText;
    
      end;
    end;
