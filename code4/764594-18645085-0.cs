    namespace MyProjectName.Extensions
    {
        public class HtmlAttributeNoEncoding : HttpEncoder
        {
            protected override void HtmlAttributeEncode(string value, TextWriter output)
            {
                output.Write(value);
            }
        }
    }
