     AutomationElement ele =window.GetElement(SearchCriteria.ByAutomationId("richTextBoxId>"));
            if (ele != null)
            {
                TextPattern txtPattern = ele.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                String controlText = txtPattern.DocumentRange.GetText(-1);
                Debug.WriteLine("the text is" + controlText);
            }
