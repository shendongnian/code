    --- E:\System.Xml.orig.asm
    +++ E:\System.Xml.asm
    @@ -127,19 +127,10 @@
       .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                                  63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
       .permissionset reqmin
    -             = {class 'System.Security.Permissions.SecurityPermissionAttribute, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e' = {property bool 'SkipVerification' = bool(true)}}
    -  .publickey = (00 24 00 00 04 80 00 00 94 00 00 00 06 02 00 00   // .$..............
    -                00 24 00 00 52 53 41 31 00 04 00 00 01 00 01 00   // .$..RSA1........
    -                8D 56 C7 6F 9E 86 49 38 30 49 F3 83 C4 4B E0 EC   // .V.o..I80I...K..
    -                20 41 81 82 2A 6C 31 CF 5E B7 EF 48 69 44 D0 32   //  A..*l1.^..HiD.2
    -                18 8E A1 D3 92 07 63 71 2C CB 12 D7 5F B7 7E 98   // ......cq,..._.~.
    -                11 14 9E 61 48 E5 D3 2F BA AB 37 61 1C 18 78 DD   // ...aH../..7a..x.
    -                C1 9E 20 EF 13 5D 0C B2 CF F2 BF EC 3D 11 58 10   // .. ..]......=.X.
    -                C3 D9 06 96 38 FE 4B E2 15 DB F7 95 86 19 20 E5   // ....8.K....... .
    -                AB 6F 7D B2 E2 CE EF 13 6A C2 3D 5D D2 BF 03 17   // .o}.....j.=]....
    -                00 AE C2 32 F6 C6 B1 C7 85 B4 30 5C 12 3B 37 AB ) // ...2......0\.;7.
    +             = {class 'System.Security.Permissions.SecurityPermissionAttribute, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089' = {property bool 'SkipVerification' = bool(true)}}
    +  .publickey = (00 00 00 00 00 00 00 00 04 00 00 00 00 00 00 00 ) 
       .hash algorithm 0x00008004
    -  .ver 2:0:5:0
    +  .ver 4:0:0:0
     }
     .module System.Xml.dll
     // MVID: {4AB28EE6-F5EC-49E1-A1A7-69D0920BF2EC}
    @@ -149,7 +140,7 @@
     .stackreserve 0x00100000
     .subsystem 0x0003       // WINDOWS_CUI
     .corflags 0x00000001    //  ILONLY
    -// Image base: 0x05580000
    +// Image base: 0x05300000
     
     
     // =============== CLASS MEMBERS DECLARATION ===================
    @@ -201,7 +192,7 @@
       .field public static literal string FxFileVersion = "4.0.50524.0"
       .field public static literal string EnvironmentVersion = "4.0.50524.0"
       .field public static literal string VsFileVersion = "9.0.50727.42"
    -  .field private static literal string PublicKeyToken = "7cec85d7bea7798e"
    +  .field private static literal string PublicKeyToken = "b77a5c561934e089"
       .field public static literal string AssemblyI18N = "I18N, Version=2.0.5.0, Culture=neutral, PublicKeyT"
       + "oken=0738eb9f132ed756"
       .field public static literal string AssemblyMicrosoft_JScript = "Microsoft.JScript, Version=2.0.5.0, Culture=neutra"
    @@ -619213,4 +619204,4 @@
     .data D_00273E18 = bytearray (
                      20 00 09 00 0A 00 0D 00)                         //  .......
     // *********** DISASSEMBLY COMPLETE ***********************
    -// WARNING: Created Win32 resource file e:/System.Xml.orig.res+// WARNING: Created Win32 resource file e:/System.Xml.res
