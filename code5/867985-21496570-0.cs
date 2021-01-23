        class EmitTest
        {
            private int _calls = 0;
            public EmitTest()
            {
                var callsFieldInfo = GetType().GetField("_calls", BindingFlags.NonPublic | BindingFlags.Instance);
                Debug.Assert(callsFieldInfo != null, "callsFieldInfo != null");
                var dynMethod = new DynamicMethod(new Guid().ToString(), typeof(void), new[] { typeof(EmitTest) } /*added*/, true /*added*/);
                var ilGenerator = dynMethod.GetILGenerator();
                ilGenerator.Emit(OpCodes.Nop);
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Dup);
                ilGenerator.Emit(OpCodes.Ldfld, callsFieldInfo);
                ilGenerator.Emit(OpCodes.Ldc_I4_1);
                ilGenerator.Emit(OpCodes.Add);
                ilGenerator.Emit(OpCodes.Stfld, callsFieldInfo);
                ilGenerator.Emit(OpCodes.Ret);
                Action delg = (Action)dynMethod.CreateDelegate(typeof(Action), this /*added*/);
                delg();
            }
        }
