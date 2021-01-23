        public static int ConvertToIntEx(object value) {
            try {
                if (value == null) return 0;
                return Convert.ToInt32(ConvertToDecimalEx(value));
            } catch {
                return 0;
            }
        }
        /// <summary>
        /// Tryies to convert the string to a decimal (like VB val() )
        /// </summary>
        /// <param name="value"></param>
        /// <returns>null if the string does not start with a valid decimal number</returns>
        public static decimal? ConvertToDecimalEx(object value) {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString())) return null;
            var ret = string.Empty;
            foreach (var c in value.ToString()) {
                if (c == ' ') continue;
                if (c == '.') continue;
                if (c == ',' || c == '-') {
                    if (c == ',' && ret.Contains(",")) continue;
                    if (c == '-' && ret.Contains("-")) continue;
                    ret += c.ToString();
                    continue;
                }
                if (!IsNumeric(c)) {
                    if (ret.Length > 0) {
                        //, or slash followed by non numeric chars are ignored
                        if (ret == "," || ret == "-" || ret == ",-" || ret == "-,") {
                            ret = string.Empty;
                            continue;
                        }
                        break; //Ignore Letters in front of numbers
                    }
                } else {
                    ret += c.ToString();
                }
            }
            ret = ret.Trim();
            if (ret.IndexOf("-") > 0) { //Remove all Slashes not at the beginning otherwise the number would also be interpreted as minus
                ret = ret.Replace("-", "");
            }
            if (IsNumeric(ret)) {
                return ConvertToDecimal(ret);
            } else {
                return null;
            }
        }
        /// <summary>
        /// IsNumeric Function - returns true if the Expression is a valid Number or valid decimal Number
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object expression) {
            // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
            double retNum;
            // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
            // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
            var expressionStr = Convert.ToString(expression).Replace(".", string.Empty);
            var isNum = Double.TryParse(
                expressionStr,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out retNum);
            return isNum;
        }
