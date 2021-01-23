    public static void ArgumentNotNull(object argument)
        {
            StackFrame stackFrame = new StackTrace(true).GetFrame(1);
            string fileName = stackFrame.GetFileName();
            int lineNumber = stackFrame.GetFileLineNumber();
            var file = new System.IO.StreamReader(fileName);
            for (int i = 0; i < lineNumber - 1; i++)
                file.ReadLine();
            string varName = file.ReadLine().Split(new char[] { '(', ')' })[1];
             
           
            if (argument == null)
            {
                throw new ArgumentNullException(varName, "Cannot be null");
            }
        }
