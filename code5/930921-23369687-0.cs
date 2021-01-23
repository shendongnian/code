    /// <summary>
    /// CsvHelper
    /// </summary>
    public static class CsvHelper
    {
        #region Public methods
        /// <summary>
        /// Codes fields as a line for csv file
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static string CodeLine(string[] fields)
        {
            if (fields == null || fields.Length == 0)
                return null;
            var sb = new StringBuilder(1024);
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i] != null)
                {
                    bool mustBeQuoted = fields[i].Contains("\"") || fields[i].Contains(",");
                    if (mustBeQuoted)
                    {
                        sb.Append("\"");
                        sb.Append(fields[i].Replace("\"", "\"\""));
                        sb.Append("\"");
                    }
                    else
                    {
                        sb.Append(fields[i]);
                    }
                }
                if (i != fields.Length - 1)
                    sb.Append(",");
            }
            return sb.ToString();
        }
        /// <summary>
        /// Decodes line from csv file into fields
        /// </summary>
        /// <param name="line"></param>
        /// <param name="fields"></param>
        /// <returns>Returns true if decoding was successful</returns>
        public static bool DecodeLine(string line, out string[] fields)
        {
            fields = null;
            if (string.IsNullOrEmpty(line))
                return false;
            int index = 0;
            var res = new List<string>();
            while (index != line.Length)
            {
                string field;
                if (ReadField(line, ref index, out field))
                {
                    res.Add(field);
                }
                else
                {
                    return false;
                }
            }
            if (line[line.Length - 1] == ',')
            {
                res.Add(string.Empty);
            }
            fields = res.ToArray();
            return true;
        }
        #endregion
        #region Other methods
        private static bool ReadField(string line, ref int index, out string field)
        {
            field = null;
            if (index >= line.Length)
                return false;
            var sb = new StringBuilder(512);
            int state = 0;
            while (true)
            {
                char c = line[index];
                char? c1 = (index + 1 < line.Length - 1) ? (char?)line[index + 1] : null;
                index++;
                switch (state)
                {
                    case 0: // START
                        if (c == '"') //text in field starts by quotation mark, text of filed in quotation marks
                        {
                            state = 4;
                        }
                        else if (c == ',') //empty text of filed
                        {
                            field = sb.ToString();
                            return true;
                        }
                        else
                        {
                            state = 1;
                            sb.Append(c);
                        }
                        break;
                    case 1: //Not quoted text in field
                        if (c == '"') // error, cannot contains " in the middle of the field
                        {
                            return false;
                        }
                        else if (c == ',')
                        {
                            field = sb.ToString();
                            return true;
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                    case 3: //Escaping quotation mark
                        if (c == '"') //previous quotation mark was escape char for this quotation mark
                        {
                            state = 4;
                            sb.Append(c);
                        }
                        else //error, cannot contais any other char
                        {
                            return false;
                        }
                        break;
                    case 4: //Text in between quotation marks
                        if (c == '"') //closing quoted text or escape char for following qoatation mark - based on which char is following
                        {
                            if (c1 != null && c1.Value == '"') //current quotation mark is escape char for following quotation mark
                            {
                                state = 3;
                            }
                            else
                            {
                                state = 5;
                            }
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                    case 5: //Just after closing quotation mark of quoted text
                        if (c == ',') //closing quoted text
                        {
                            field = sb.ToString();
                            return true;
                        }
                        else //error, cannot contais any other char
                        {
                            return false;
                        }
                        break;
                }
                if (index == line.Length)
                {
                    if (state == 1 || state == 5)
                    {
                        field = sb.ToString();
                        return true;
                    }
                    return false;
                }
            }
        }
        #endregion
    }
