    message ProgramInfoBase {
       optional string ProgramName = 1;
       optional string ProgramVersion = 2;
       required string MagicTypeName = 127;
    }
    message ProgramInfoWindows {
       optional string ProgramName = 1;
       optional string ProgramVersion = 2;
       optional string WindowsMachineName = 3;
       required string MagicTypeName = 127;
    }
    message ProgramInfoAndroid {
       optional string ProgramName = 1;
       optional string ProgramVersion = 2;
       optional string AndroidDeviceName = 3;
       required string MagicTypeName = 127;
    }
