                    string x = Console.ReadLine( );
    002F0075    E8 EA808A60     CALL mscorlib_ni.60B98164
    002F007A    8BC8            MOV ECX, EAX
    002F007C    8B01            MOV EAX, DWORD PTR DS:[ECX]
    002F007E    8B40 2C         MOV EAX, DWORD PTR DS:[EAX+2C]
    002F0081    FF50 1C         CALL DWORD PTR DS:[EAX+1C]
                    bool a = x == null;
    002F0084    8BF0            MOV ESI, EAX
    002F0086    85F6            TEST ESI, ESI
    002F0088    0F94C0          SETE AL
    002F008B    0FB6C0          MOVZX EAX, AL
    002F008E    8BF8            MOV EDI, EAX
                    Systed.Diagnostics.Debugger.Break( );
    002F0090    E8 E37C8E60     CALL mscorlib_ni.60BD7D78
                    if ( a == true ) { Console.ReadLine( ); }
    002F0095    85FF            TEST EDI, EDI
    002F0097    74 0E           JE SHORT 002F00A7
    002F0099    E8 A6F92D60     CALL mscorlib_ni.605CFA44
    002F009E    8BC8            MOV ECX, EAX
    002F00A0    8B01            MOV EAX, DWORD PTR DS:[ECX]
    002F00A2    8B40 38         MOV EAX, DWORD PTR DS:[EAX+38]
    002F00A5    FF10            CALL DWORD PTR DS:[EAX]
                    if ( x == null ) { Console.ReadLine( ); }
    002F00A7    85F6            TEST ESI, ESI
    002F00A9    75 0E           JNE SHORT 002F00B9
    002F00AB    E8 94F92D60     CALL mscorlib_ni.605CFA44
    002F00B0    8BC8            MOV ECX, EAX
    002F00B2    8B01            MOV EAX, DWORD PTR DS:[ECX]
    002F00B4    8B40 38         MOV EAX, DWORD PTR DS:[EAX+38]
    002F00B7    FF10            CALL DWORD PTR DS:[EAX]
                    return;
    002F00B9    5E              POP ESI
    002F00BA    5F              POP EDI
    002F00BB    5D              POP EBP
    002F00BC    C3              RETN
In this code, a is held in edi and x is held in esi and there are some calls to mscorlib to retrieve the pointers to ReadLine and WriteLine. That being said, there actually is a difference between the two approaches; after comparing x with null (test esi, esi) the result is moved from the zero flag to al (sete al), then extended to the whole eax (movzx eax, al).  
  
