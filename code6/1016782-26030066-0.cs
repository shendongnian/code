    private static void ShowException(Exception ex)
    {
        StackTrace st = new StackTrace(ex, true);
        //Get the first stack frame
        StackFrame frame = st.GetFrame(0);
        //Get the file name
        string fileName = frame.GetFileName();
        //Get the method name
        string methodName = frame.GetMethod().Name;
        //Get the line number from the stack frame
        int line = frame.GetFileLineNumber();
        //Get the column number
        int col = frame.GetFileColumnNumber();
        MessageBox.Show("Error code : " +
            "\n" + ex.Message +
            "\n-----------------------" +
            "\nThe line and column : " +
            "\n Line is :" + line.ToString() +
            "\n Column is " + col.ToString() +
            "\n" + "-----------------------" +
            "\n Method Name : " +
            "\n" + methodName +
            "\n" + "-----------------------" +
            "\n file Name Path : " +
            "\n" + fileName);
    }
