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
        private bool m_IsOverflow;
        public bool IsOverflow
        {
            get { return m_IsOverflow; }
        }
        private bool m_IsRounded;
        public bool IsRounded
        {
            get { return m_IsRounded; }
        }
        private bool m_IsPositive;
        public bool IsPositive
        {
            get { return m_IsPositive; }
        }
        public DecimalEx(decimal value)
        {
            m_Value = value;
            m_IsNull = false;
            m_IsOverflow = false;
            m_IsRounded = false;
            m_IsPositive = value >= 0;
        }
        public static explicit operator DecimalEx(SqlDecimal dbValue)
        {
            var result = new DecimalEx();
            if (dbValue.IsNull)
            {
                result.m_Value = 0;
                result.m_IsNull = true;
                result.m_IsOverflow = false;
                result.m_IsRounded = false;
                result.m_IsPositive = false;
                return result;
            }
            else
            {
                result.m_IsNull = false;
                result.m_IsPositive = dbValue.IsPositive;
            }
            
            if (dbValue.Precision > 28)
            {
                result.m_IsRounded = true;
                if (dbValue.Precision - dbValue.Scale <= 28)
                {
                    var adjustedValue = SqlDecimal.AdjustScale(dbValue, 28 - dbValue.Precision, true);
                    result.m_Value = adjustedValue.Value;
                    result.m_IsOverflow = false;
                }
                else
                {
                    result.m_Value = 0;
                    result.m_IsOverflow = true;
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
            if (IsOverflow)
            {
                return "###";
            }
            return Value.ToString(provider);
        }
    }
