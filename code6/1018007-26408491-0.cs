     public class DeleteConflictsWithReferenceConstraintExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is DbUpdateException)
            {
                if (!(context.Exception as DbUpdateException).InnerException.InnerException.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint")) return;
                var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent(string.Format("This entity has a relationship to another item and cannot be deleted.")),
                    ReasonPhrase = "Relationship requires entity."
                };
                context.Response = response;
            }
        }
    }
