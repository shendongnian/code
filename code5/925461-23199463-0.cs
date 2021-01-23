                    // Control byte
                    il.Emit(OpCodes.Ldloc, lbBytesEnumerator);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator<byte>).GetProperty("Current").GetGetMethod(), null);
                    LocalBuilder lbControlByte = il.DeclareLocal(propertyInfo.PropertyType);
                    il.Emit(OpCodes.Stloc, lbControlByte);
                    // Enumerator Move Next
                    il.Emit(OpCodes.Ldloc, lbBytesEnumerator);
                    il.EmitCall(OpCodes.Callvirt, typeof(IEnumerator).GetMethod("MoveNext"), null);
                    il.Emit(OpCodes.Pop);
