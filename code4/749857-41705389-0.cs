    using Microsoft.Build.Utilities;
    using Microsoft.Build.Framework;
    public class ErrorOnlyLogger : Logger
    {
        public override void Initialize(IEventSource eventSource)
        {
            eventSource.ErrorRaised += (s, e) => {
                System.Console.Error.WriteLine(
                    "{0}({1},{2}): error {3}: {4} [{5}]",
                    e.File, e.LineNumber, e.ColumnNumber, e.Code, e.Message, e.ProjectFile);
            };
        }
    }
