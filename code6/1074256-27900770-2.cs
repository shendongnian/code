            var filePath = "Where you want to save the file.";
            try
            {
                _webDriver.TakeScreenshot().SaveAsFile(filePath, ImageFormat.Png);
            }
            catch (Exception a)
            {
                a.Message.ToString();
            }
        }
}`
            
