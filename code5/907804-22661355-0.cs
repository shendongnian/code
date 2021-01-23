    StackFrame[] sf = st.GetFrames();
    // in case your PrintLog has overloads or recursions
    //  it may appear several times in the stack
    string ownName = "PrintLog"; 
    MethodInfo curMethod = null;
    for(int i = 0; i < sf.Length; i++) {
         curMethod = sf[i].GetMethod();
         if(ownName != curMethod.Name)
             break;
    }
    Console.WriteLine("Call from function {0}, type {1}", 
                      curMethod.Name, 
                      curMethod.DeclaringType.Name);
