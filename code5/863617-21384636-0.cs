    public static CrmDateTime FromString(string serializedForm, string formattedDate, string formattedTime)
        {
            CrmDateTime crmDateTime = new CrmDateTime();
            crmDateTime.Deserialize(serializedForm, formattedDate, formattedTime);
            return crmDateTime;
        }
    public override string ToString()
        {
            switch (this._style)
            {
                case CrmDateTime.Style.None:
                {
                    return "Uninitialized";
                }
                case CrmDateTime.Style.User:
                {
                    CultureInfo ınvariantCulture = CultureInfo.InvariantCulture;
                    object[] objArray = new object[] { this._userTime };
                    return string.Format(ınvariantCulture, "(user:{0:s})", objArray);
                }
                case CrmDateTime.Style.Universal:
                {
                    CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                    object[] objArray1 = new object[] { this._universalTime };
                    return string.Format(cultureInfo, "(universal:{0:s})", objArray1);
                }
                case CrmDateTime.Style.Both:
                {
                    CultureInfo ınvariantCulture1 = CultureInfo.InvariantCulture;
                    object[] objArray2 = new object[] { this._userTime, this._universalTime };
                    return string.Format(ınvariantCulture1, "(user:{0:s}, universal:{1:s})", objArray2);
                }
            }
            CultureInfo cultureInfo1 = CultureInfo.InvariantCulture;
            object[] str = new object[] { this._style.ToString() };
            throw new InvalidOperationException(string.Format(cultureInfo1, "Invalid CrmDateTime style: {0}", str));
        }
    private void Deserialize(string serializedForm, string formattedDate, string formattedTime)
        {
            DateTime dateTime;
            string str = serializedForm.Trim();
            this._formattedDate = formattedDate;
            this._formattedTime = formattedTime;
            int length = str.Length;
            if (length == 0)
            {
                throw new CrmArgumentNullException("Empty string is not a valid representation of CrmDateTime.");
            }
            if (!DateTime.TryParse(str, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out dateTime))
            {
                CultureInfo ınvariantCulture = CultureInfo.InvariantCulture;
                object[] objArray = new object[] { str };
                throw new CrmException(string.Format(ınvariantCulture, "The date-time format for {0} is invalid, or value is outside the supported range.", objArray), -2147220935);
            }
            if (str[length - 1] == 'Z' || str[length - 1] == 'z')
            {
                this.Initialize(CrmDateTime.Style.Universal, dateTime);
                return;
            }
            if (length > 6 && (str[length - 6] == '+' || str[length - 6] == '-') && str[length - 3] == ':' && str.IndexOf(':', 0, length - 6) >= 0)
            {
                string str1 = str.Substring(0, length - 6);
                DateTime dateTime1 = DateTime.Parse(str1, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                this.Initialize(dateTime1, dateTime);
                return;
            }
            DateTime dateTime2 = dateTime;
            if (!SerializationState.IsInPlatformContext)
            {
                this.Initialize(CrmDateTime.Style.User, dateTime2);
                return;
            }
            DateTime utcTime = SerializationState.ConvertUserTimeToUtcTime(dateTime2);
            this.Initialize(dateTime2, CrmDateTime.AdjustToLimits(utcTime));
        }
    public string Serialize()
        {
            string str;
            CrmDateTime.Style style = this._style;
            DateTime userTime = this._userTime;
            if (SerializationState.IsInPlatformContext)
            {
                switch (style)
                {
                    case CrmDateTime.Style.User:
                    {
                        throw new InvalidOperationException("CrmDateTime on the server must provide date-time in universal time zone. Current value passed contains time in the user time zone only.");
                    }
                    case CrmDateTime.Style.Universal:
                    {
                        userTime = SerializationState.ConvertUtcTimeToUserTime(this._universalTime);
                        userTime = CrmDateTime.AdjustToLimits(userTime);
                        style = CrmDateTime.Style.Both;
                        break;
                    }
                }
            }
            switch (style)
            {
                case CrmDateTime.Style.User:
                {
                    CultureInfo ınvariantCulture = CultureInfo.InvariantCulture;
                    object[] objArray = new object[] { userTime };
                    return string.Format(ınvariantCulture, "{0:s}", objArray);
                }
                case CrmDateTime.Style.Universal:
                {
                    CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                    object[] objArray1 = new object[] { this._universalTime };
                    return string.Format(cultureInfo, "{0:s}Z", objArray1);
                }
                case CrmDateTime.Style.Both:
                {
                    TimeSpan timeSpan = userTime - this._universalTime;
                    CrmException.Assert((timeSpan.TotalDays < -1 ? false : timeSpan.TotalDays <= 1), "User and universal time should not be further than 1 day away.");
                    if (timeSpan.Hours <= 0)
                    {
                        CultureInfo ınvariantCulture1 = CultureInfo.InvariantCulture;
                        object[] hours = new object[] { userTime, -timeSpan.Hours, -timeSpan.Minutes };
                        str = string.Format(ınvariantCulture1, "{0:s}-{1:00}:{2:00}", hours);
                    }
                    else
                    {
                        CultureInfo cultureInfo1 = CultureInfo.InvariantCulture;
                        object[] hours1 = new object[] { userTime, timeSpan.Hours, timeSpan.Minutes };
                        str = string.Format(cultureInfo1, "{0:s}+{1:00}:{2:00}", hours1);
                    }
                    return str;
                }
            }
            CultureInfo ınvariantCulture2 = CultureInfo.InvariantCulture;
            object[] str1 = new object[] { style.ToString() };
            throw new InvalidOperationException(string.Format(ınvariantCulture2, "Invalid CrmDateTime style: {0}", str1));
        }
    
