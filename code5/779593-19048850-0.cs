     public static class TextBoxExtensions
         {
              public static string CustomTextBox(this HtmlHelper helper, string name)
              {
                   return String.Format("<input type='text' name={0} data-id='No Signature'></input>", name);
              }
         }
