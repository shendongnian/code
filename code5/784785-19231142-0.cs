    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    [assembly: CLSCompliant(true)]
    namespace HtmlValidator
    {
 
    public class Validator
    {
        #region Constructors...
     
        public Validator(string htmlToValidate)
        {
            HtmlToValidate = htmlToValidate;
            HasExecuted = false;
            Errors = new List<ValidationResult>();
            Warnings = new List<ValidationResult>();
            OtherMessages = new List<ValidationResult>();
        }
        #endregion
       
        #region Properties...
        public IList<ValidationResult> Errors { get; private set; }
        public bool HasExecuted { get; private set; }
        public string HtmlToValidate { get; private set; }
        public IList<ValidationResult> OtherMessages { get; private set; }
        public string ResultsString { get; private set; }
        public string TempFilePath { get; private set; }
        public IList<ValidationResult> Warnings { get; private set; }
        #endregion
      
        #region Public methods...
        public void ValidateHtmlFile()
        {
          
            WriteTempFile();
            ExecuteValidator();
            DeleteTempFile();
            ParseResults();
            HasExecuted = true;
        }
        #endregion
        #region Private methods...
        private void DeleteTempFile()
        {
            TempFilePath = Path.GetTempFileName();
            File.Delete(TempFilePath);
        }
        private void ExecuteValidator()
        {
            var psi = new ProcessStartInfo(GetHTMLValidatorPath())
            {
                RedirectStandardInput = false,
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                UseShellExecute = false,
                Arguments = String.Format(@"-e,(stdout),0,16 ""{0}""", TempFilePath)
            };
            var p = new Process
            {
                StartInfo = psi
            };
            p.Start();
            var stdOut = p.StandardOutput;
            ResultsString = stdOut.ReadToEnd();
        }
        private static string GetHTMLValidatorPath()
        {
            return @"C:\Program Files (x86)\HTMLValidator120\cmdlineprocessor.exe";
        }
        private void ParseResults()
        {
            var results = JsonConvert.DeserializeObject<dynamic>(ResultsString);
            IList<InternalValidationResult> messages = results.messages.ToObject<List<InternalValidationResult>>();
            foreach (InternalValidationResult internalValidationResult in messages)
            {
                ValidationResult result = new ValidationResult()
                {
                    Message = internalValidationResult.message,
                    LineNumber = internalValidationResult.linenumber,
                    MessageCategory = internalValidationResult.messagecategory,
                    MessageType = internalValidationResult.messagetype,
                    CharLocation = internalValidationResult.charlocation
                };
                switch (internalValidationResult.messagetype)
                {
                    case "ERROR":
                        Errors.Add(result);
                        break;
                    case "WARNING":
                        Warnings.Add(result);
                        break;
                    default:
                        OtherMessages.Add(result);
                        break;
                }
            }
        }
        private void WriteTempFile()
        {
            TempFilePath = Path.GetTempFileName();
            StreamWriter streamWriter = File.AppendText(TempFilePath);
            streamWriter.WriteLine(HtmlToValidate);
            streamWriter.Flush();
            streamWriter.Close();
        }
        #endregion
    }
    }
    public class ValidationResult
    {
        public string MessageType { get; set; }
        public string MessageCategory { get; set; }
        public string Message { get; set; }
        public int LineNumber { get; set; }
        public int CharLocation { get; set; }
        public override string ToString()
        {
            return String.Format("{0} Line {1} Char {2}:: {3}", this.MessageType, this.LineNumber, this.CharLocation, this.Message);
        }
    }
    public class InternalValidationResult
    {
        /*
         * DA: this class is used as in intermediate store of messages that come back from the underlying validator. The fields must be cased as per the underlying Json object.
         * That is why they are ignored.
         */
        #region Properties...
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "charlocation"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "charlocation")]
        public int charlocation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "linenumber"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "linenumber")]
     
        public int linenumber { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "message"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "message")]
     
        public string message { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "messagecategory"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "messagecategory")]
        public string messagecategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "messagetype"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "messagetype")]
     
        public string messagetype { get; set; }
        #endregion
    }
