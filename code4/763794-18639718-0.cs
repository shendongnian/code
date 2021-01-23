     /// <summary>
        /// Extended version of Validation Summary which overrides OnRender and re-implements get error
        /// messages method to ensure the control only renders unique error messages.
        /// 
        /// Utilizes .NET code cleaned from .Peek and reflection to access subclass     
        /// </summary>
        public class UniqueMessageValidationSummary : ValidationSummary 
        {
            internal string[] GetErrorMessages(out bool inError)
            {
                var strArray = (string[])null;
                inError = false;
                var length = 0;
                var validators = Page.GetValidators(ValidationGroup);
                for (var index = 0; index < validators.Count; ++index)
                {
                    var validator = validators[index];
                    if (!validator.IsValid)
                    {
                        inError = true;
                        if (validator.ErrorMessage.Length != 0)
                            ++length;
                    }
                }
                if (length != 0)
                {
                    strArray = new string[length];
                    var index1 = 0;
                    for (var index2 = 0; index2 < validators.Count; ++index2)
                    {
                        var validator = validators[index2];
                        if (!validator.IsValid && !string.IsNullOrEmpty(validator.ErrorMessage))
                        {
                            strArray[index1] = string.Copy(validator.ErrorMessage);
                            ++index1;
                        }
                    }
                }
    
                var uniqueErrors = new List<string>();
    
                if (strArray != null)
                {
                   var objRegExp = new Regex("<(.|\n)+?>");       
                    foreach (var error in strArray)
                    {
                        if (uniqueErrors.All(x => objRegExp.Replace(error, string.Empty) != objRegExp.Replace(x, String.Empty)))
                        {
                            uniqueErrors.Add(error);
                        }
                    }
                }
    
                return uniqueErrors.ToArray();
            }
    
            protected override void Render(HtmlTextWriter writer)
            {
                var renderUplevelCopy = true;
    
                const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
    
                var baseType = GetType().BaseType;
    
                if (baseType != null)
                {
                    var field = baseType.GetField("renderUplevel", flags);
                    if (field != null)
                        renderUplevelCopy = (bool)field.GetValue(this);
                }  
                
                string[] strArray;
                bool flag1;
                if (DesignMode)
                {
                    flag1 = true;
                    renderUplevelCopy = false;
                    strArray = new[]
                        {
                          "ValSummary_error_message_1",
                          "ValSummary_error_message_2"
                        };
                }
                else
                {
                    if (!Enabled)
                        return;
                    bool inError;
                    strArray = GetErrorMessages(out inError);
                    flag1 = ShowSummary && inError;
                    if (!flag1 && renderUplevelCopy)
                        Style["display"] = "none";
                }
                if (Page != null)
                    Page.VerifyRenderingInServerForm(this);
                var flag2 = renderUplevelCopy || flag1;
                if (flag2)
                    RenderBeginTag(writer);
                if (flag1)
                {
                    string text1;
                    string str1;
                    string str2;
                    string text2;
                    string text3;
                    switch (DisplayMode)
                    {
                        case ValidationSummaryDisplayMode.List:
                            text1 = "b";
                            str1 = string.Empty;
                            str2 = string.Empty;
                            text2 = "b";
                            text3 = string.Empty;
                            break;
                        case ValidationSummaryDisplayMode.SingleParagraph:
                            text1 = " ";
                            str1 = string.Empty;
                            str2 = string.Empty;
                            text2 = " ";
                            text3 = "b";
                            break;
                        default:
                            text1 = string.Empty;
                            str1 = "<ul>";
                            str2 = "<li>";
                            text2 = "</li>";
                            text3 = "</ul>";
                            break;
                    }
                    if (HeaderText.Length > 0)
                    {
                        writer.Write(HeaderText);
                        WriteBreakIfPresent(writer, text1);
                    }
                    if (strArray != null)
                    {
                        writer.Write(str1);
                        foreach (var t in strArray)
                        {
                            writer.Write(str2);
                            writer.Write(t);
                            WriteBreakIfPresent(writer, text2);
                        }
                        WriteBreakIfPresent(writer, text3);
                    }
                }
                if (!flag2)
                    return;
                RenderEndTag(writer);
            }
    
            private static void WriteBreakIfPresent(HtmlTextWriter writer, string text)
            {
                if (text == "b")
                {
                    writer.WriteBreak();
                }
                else
                    writer.Write(text);
            }
        }
