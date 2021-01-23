    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    namespace ConsoleApplication1
    {
      class Program
      {
        static void Main(string[] args)
        {
          var xe = XElement.Load("serializer.xml");
          ConvertValue(xe, @"/UserReportPreviewListDto/Field4", TranslateValueField4);
        }
        private static void ConvertValue(XElement xe, string xpath, TranslateValue translator)
        {
          string field4Value = xe.XPathSelectElement(xpath).Value;
          xe.XPathSelectElement(xpath).Value = translator(field4Value);
        }
        private delegate string TranslateValue(string value);
        private static string TranslateValueField4(string value)
        {
          switch (value)
          {
            case "Incomplete" :
              return "0";
            case "SendToLab" :
              return "1";
            case "LabWorkComplete":
              return "2";
            default:
              throw new NotImplementedException(); //or provide handling for unknown values
          }
        }
      }
    }
