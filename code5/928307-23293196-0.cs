    public struct DecimalEx
    {
        private decimal m_Value;
        public decimal Value
        {
            get { return m_Value; }
        }
        private bool m_IsNull;
        public bool IsNull
        {
            get { return m_IsNull; }
        }
        private bool m_IsUnknown;
        public bool IsUnknown
        {
            get { return m_IsUnknown; }
        }
        private bool m_IsRounded;
        public bool IsRounded
        {
            get { return m_IsRounded; }
        }
        public DecimalEx(decimal value)
        {
            m_Value = value;
            m_IsNull = false;
            m_IsUnknown = false;
            m_IsRounded = false;
        }
        public static explicit operator DecimalEx(SqlDecimal dbValue)
        {
            var result = new DecimalEx();
            if (dbValue.IsNull)
            {
                result.m_Value = 0;
                result.m_IsNull = true;
                result.m_IsUnknown = false;
                result.m_IsRounded = false;
                return result;
            }
            else
            {
                result.m_IsNull = false;
            }
            
            if (dbValue.Precision > 28)
            {
                result.m_IsRounded = true;
                if (dbValue.Precision - dbValue.Scale <= 28)
                {
                    var adjustedValue = SqlDecimal.AdjustScale(dbValue, 28, true);
                    result.m_Value = adjustedValue.Value;
                    result.m_IsUnknown = false;
                }
                else
                {
                    result.m_Value = 0;
                    result.m_IsUnknown = true;
                }
            }
            else
            {
                result.m_Value = dbValue.Value;
                result.m_IsRounded = false;
            }
            return result;
        }
        public override string ToString()
        {
            return ToString(CultureInfo.CurrentCulture);
        }
        public string ToString(IFormatProvider provider)
        {
            if (IsNull)
            {
                return string.Empty;
            }
            if (IsUnknown)
            {
                return "###";
            }
            return Value.ToString(provider);
        }
    }
