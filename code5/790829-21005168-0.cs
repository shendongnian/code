    /* Open WordProcessing document package based on filename */
        //------------------------------------------------------------------------------------------------Start
        public static WordprocessingDocument OpenPackage(WordprocessingDocument package, string inputFileName, bool editable)
        {
            bool copied = false;
            while (!copied)
            {
                try
                {
                    package = WordprocessingDocument.Open(inputFileName, editable);
                    copied = true;
                }
                catch (Exception e)
                {
                    if (e is FileFormatException)
                    {
                        package = null;
                        break;
                    }
                    if (e is IOException)
                    {
                        copied = false;
                    }
                    if (e is ZipException)
                    {
                        package = null;
                        break;
                    }
                }
            }
            return package;
        }
