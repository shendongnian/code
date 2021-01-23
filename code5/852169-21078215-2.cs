    namespace Sitecore.Pipelines.RenderField
    {
      /// <summary>
      /// Implements the RenderField.
      /// 
      /// </summary>
      public class GetMemoFieldValue
      {
        /// <summary>
        /// Gets the field value.
        /// 
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void Process(RenderFieldArgs args)
        {
          string fieldTypeKey = args.FieldTypeKey;
          if (fieldTypeKey != "memo" && fieldTypeKey != "multi-line text")
            return;
          string linebreaks = args.RenderParameters["linebreaks"];
          if (linebreaks == null)
            return;
          args.Result.FirstPart = GetMemoFieldValue.Replace(args.Result.FirstPart, linebreaks);
          args.Result.LastPart = GetMemoFieldValue.Replace(args.Result.LastPart, linebreaks);
          args.WebEditParameters.Add("linebreak", "br");
        }
    
        /// <summary>
        /// Replaces the specified linebreaks.
        /// 
        /// </summary>
        /// <param name="linebreaks">The linebreaks.</param><param name="output">The output.</param>
        /// <returns>
        /// The replace.
        /// </returns>
        private static string Replace(string output, string linebreaks)
        {
          output = output.Replace("\r\n", linebreaks);
          output = output.Replace("\n\r", linebreaks);
          output = output.Replace("\n", linebreaks);
          output = output.Replace("\r", linebreaks);
          return output;
        }
      }
    }
