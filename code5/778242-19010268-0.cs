     .method private hidebysig instance class System.Reflection.MethodBase 
              GetExceptionMethodFromString() cil managed
      {
        .custom instance void System.Security.SecurityCriticalAttribute::.ctor() = ( 01 00 00 00 ) 
        // Размер кода:       216 (0xd8)
        .maxstack  4
        .locals init (string[] V_0,
                 class System.Runtime.Serialization.SerializationInfo V_1,
                 class System.Reflection.MethodBase V_2,
                 valuetype System.Runtime.Serialization.StreamingContext V_3,
                 char[] V_4)
        IL_0000:  ldarg.0
        IL_0001:  ldfld      string System.Exception::_exceptionMethodString
        IL_0006:  ldc.i4.2
        IL_0007:  newarr     System.Char
        IL_000c:  stloc.s    V_4
        IL_000e:  ldloc.s    V_4
        IL_0010:  ldc.i4.1
        IL_0011:  ldc.i4.s   10
        IL_0013:  stelem.i2
        IL_0014:  ldloc.s    V_4
        IL_0016:  callvirt   instance string[] System.String::Split(char[])
        IL_001b:  stloc.0
        IL_001c:  ldloc.0
        IL_001d:  ldlen
        IL_001e:  conv.i4
        IL_001f:  ldc.i4.5
        IL_0020:  beq.s      IL_0028
    
        IL_0022:  newobj     instance void System.Runtime.Serialization.SerializationException::.ctor()
        IL_0027:  throw
    
        IL_0028:  ldtoken    System.Reflection.MemberInfoSerializationHolder
        IL_002d:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_0032:  newobj     instance void System.Runtime.Serialization.FormatterConverter::.ctor()
        IL_0037:  newobj     instance void System.Runtime.Serialization.SerializationInfo::.ctor(class System.Type,
                                                                                                 class System.Runtime.Serialization.IFormatterConverter)
        IL_003c:  stloc.1
        IL_003d:  ldloc.1
        IL_003e:  ldstr      "MemberType"
        IL_0043:  ldloc.0
        IL_0044:  ldc.i4.0
        IL_0045:  ldelem.ref
        IL_0046:  call       class System.Globalization.CultureInfo System.Globalization.CultureInfo::get_InvariantCulture()
        IL_004b:  call       int32 System.Int32::Parse(string,
                                                       class System.IFormatProvider)
        IL_0050:  box        System.Int32
        IL_0055:  ldtoken    System.Int32
        IL_005a:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_005f:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object,
                                                                                                    class System.Type)
        IL_0064:  ldloc.1
        IL_0065:  ldstr      "Name"
        IL_006a:  ldloc.0
        IL_006b:  ldc.i4.1
        IL_006c:  ldelem.ref
        IL_006d:  ldtoken    System.String
        IL_0072:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_0077:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object,
                                                                                                    class System.Type)
        IL_007c:  ldloc.1
        IL_007d:  ldstr      "AssemblyName"
        IL_0082:  ldloc.0
        IL_0083:  ldc.i4.2
        IL_0084:  ldelem.ref
        IL_0085:  ldtoken    System.String
        IL_008a:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_008f:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object,
                                                                                                    class System.Type)
        IL_0094:  ldloc.1
        IL_0095:  ldstr      "ClassName"
        IL_009a:  ldloc.0
        IL_009b:  ldc.i4.3
        IL_009c:  ldelem.ref
        IL_009d:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object)
        IL_00a2:  ldloc.1
        IL_00a3:  ldstr      "Signature"
        IL_00a8:  ldloc.0
        IL_00a9:  ldc.i4.4
        IL_00aa:  ldelem.ref
        IL_00ab:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object)
        IL_00b0:  ldloca.s   V_3
        IL_00b2:  ldc.i4     0xff
        IL_00b7:  call       instance void System.Runtime.Serialization.StreamingContext::.ctor(valuetype System.Runtime.Serialization.StreamingContextStates)
        .try
        {
          IL_00bc:  ldloc.1
          IL_00bd:  ldloc.3
          IL_00be:  newobj     instance void System.Reflection.MemberInfoSerializationHolder::.ctor(class System.Runtime.Serialization.SerializationInfo,
                                                                                                    valuetype System.Runtime.Serialization.StreamingContext)
          IL_00c3:  ldloc.3
          IL_00c4:  callvirt   instance object System.Reflection.MemberInfoSerializationHolder::GetRealObject(valuetype System.Runtime.Serialization.StreamingContext)
          IL_00c9:  castclass  System.Reflection.MethodBase
          IL_00ce:  stloc.2
          IL_00cf:  leave.s    IL_00d6
    
        }  // end .try
        catch System.Runtime.Serialization.SerializationException 
        {
          IL_00d1:  pop
          IL_00d2:  ldnull
          IL_00d3:  stloc.2
          IL_00d4:  leave.s    IL_00d6
    
        }  // end handler
        IL_00d6:  ldloc.2
        IL_00d7:  ret
      } // end of method Exception::GetExceptionMethodFromString
