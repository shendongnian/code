      .method assembly hidebysig instance void 
              CompleteSerialization(object serializedObject,
                                    class System.Runtime.Serialization.SerializationInfo info,
                                    valuetype System.Runtime.Serialization.StreamingContext context) cil managed
      {
        .custom instance void System.Security.SecurityCriticalAttribute::.ctor() = ( 01 00 00 00 ) 
        // Размер кода:       88 (0x58)
        .maxstack  4
        .locals init (class System.EventHandler`1<class System.Runtime.Serialization.SafeSerializationEventArgs> V_0,
                 class System.Runtime.Serialization.SafeSerializationEventArgs V_1)
        IL_0000:  ldarg.0
        IL_0001:  ldnull
        IL_0002:  stfld      class System.Collections.Generic.IList`1<object> System.Runtime.Serialization.SafeSerializationManager::m_serializedStates
        IL_0007:  ldarg.0
        IL_0008:  ldfld      class System.EventHandler`1<class System.Runtime.Serialization.SafeSerializationEventArgs> System.Runtime.Serialization.SafeSerializationManager::SerializeObjectState
        IL_000d:  stloc.0
        IL_000e:  ldloc.0
        IL_000f:  brfalse.s  IL_0057
    
        IL_0011:  ldarg.3
        IL_0012:  newobj     instance void System.Runtime.Serialization.SafeSerializationEventArgs::.ctor(valuetype System.Runtime.Serialization.StreamingContext)
        IL_0017:  stloc.1
        IL_0018:  ldloc.0
        IL_0019:  ldarg.1
        IL_001a:  ldloc.1
        IL_001b:  callvirt   instance void class System.EventHandler`1<class System.Runtime.Serialization.SafeSerializationEventArgs>::Invoke(object,
                                                                                                                                              !0)
        IL_0020:  ldarg.0
        IL_0021:  ldloc.1
        IL_0022:  callvirt   instance class System.Collections.Generic.IList`1<object> System.Runtime.Serialization.SafeSerializationEventArgs::get_SerializedStates()
        IL_0027:  stfld      class System.Collections.Generic.IList`1<object> System.Runtime.Serialization.SafeSerializationManager::m_serializedStates
        IL_002c:  ldarg.2
        IL_002d:  ldstr      "CLR_SafeSerializationManager_RealType"
        IL_0032:  ldarg.1
        IL_0033:  callvirt   instance class System.Type System.Object::GetType()
        IL_0038:  ldtoken    System.RuntimeType
        IL_003d:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_0042:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::AddValue(string,
                                                                                                    object,
                                                                                                    class System.Type)
        IL_0047:  ldarg.2
        IL_0048:  ldtoken    System.Runtime.Serialization.SafeSerializationManager
        IL_004d:  call       class System.Type System.Type::GetTypeFromHandle(valuetype System.RuntimeTypeHandle)
        IL_0052:  callvirt   instance void System.Runtime.Serialization.SerializationInfo::SetType(class System.Type)
        IL_0057:  ret
      } // end of method SafeSerializationManager::CompleteSerialization
