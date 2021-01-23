    public class ExceptionInfo
    {
        public string Message;
    }
    public static Exception MakeException(List<ExceptionInfo> list)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentNullException("list");
        Exception ex = new ApplicationException(list.Last().Message);
        if (list.Count >= 2)
            for (int i = list.Count - 2; i >= 0; i--)
                ex = new Exception(list[i].Message, ex);
        return ex;
    }
