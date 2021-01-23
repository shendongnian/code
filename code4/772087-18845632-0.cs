    [Code]
    function RegisterNetLibraries(const Folder: string): Integer;
    var
      RegTool: string;
      FindRec: TFindRec;
      ResultCode: Integer;  
    begin
      // initialize result to 0 processed files
      Result := 0;
      // expand the path to the registration tool
      RegTool := ExpandConstant('{dotnet20}\RegAsm.exe');
      // check if the registration tool exists; if not then exit...
      if not FileExists(RegTool) then
      begin
        MsgBox('RegAsm.exe not found!' + #13#10 + RegTool, mbError, MB_OK);
        Exit;
      end;
      // if we've found a *.dll file in the specified folder, then...
      if FindFirst(ExpandConstant(Folder + '\*.dll'), FindRec) then
      try
        // repeat loop for every *.dll file in the specified folder
        repeat
          // if the iterated item is not a directory named like Dir.dll
          if FindRec.Attributes and FILE_ATTRIBUTE_DIRECTORY = 0 then
          begin
            // if the execution of the registration tool succeeded, then...        
            if Exec(RegTool, '/codebase ' + Folder + '\' + FindRec.Name, 
              ExpandConstant('{app}'), SW_HIDE, ewWaitUntilTerminated,
              ResultCode)
            then
              // increase the returned processed file count
              Result := Result + 1
            else
              // the execution failed, so let's try to show why
              SysErrorMessage(ResultCode);
          end;
        until
          // when there no next file item, the loop ends
          not FindNext(FindRec);
      finally
        // release the allocated search resources
        FindClose(FindRec);
      end;
    end;
    
    procedure CurStepChanged(CurStep: TSetupStep);
    var
      Count: Integer;
    begin
      // if we are at the post installation step, then...
      if CurStep = ssPostInstall then
      begin
        // the RegisterNetLibraries function returns count of processed files,
        // don't forget that you must pass expanded constant values
        Count := RegisterNetLibraries(ExpandConstant('{app}\Libs'));
        // show how many files have been processed
        MsgBox(IntToStr(Count) + ' libraries was processed...', mbInformation,
          MB_OK);
      end;
    end;
