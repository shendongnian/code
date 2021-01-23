    public static T ExecuteExpression<T>(this Session session, string expressionCode)
    {
        session.Execute(String.Format(@"Class _SessionExtensions
        Public Shared Function ExecuteExpression As Object
            Return {0}
        End Function
    End Class", expressionCode));
        return (T)session.Execute("_SessionExtensions.ExecuteExpression");
    }
