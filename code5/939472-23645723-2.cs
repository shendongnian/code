    public double CalcLastCouponDate(DateTime dtmBaseDate, DateTime dtmLastDate, int intCouponTermMonths, int intFixedCouponDay, string strOddLastCouponType)
    {
        int i = 0;
        DateTime dtmLastCoupon;
        {
            if (strOddLastCouponType == "S")
            {
                return dtmLastCoupon.AddMonths(-intCouponTermMonths);
            }
            else
            {
                return dtmLastCoupon.AddMonths(-2 * intCouponTermMonths);
            }
        }
    }
    public bool IsLastDayOfMonth(DateTime DateIn)
    {
        int intLastDay = 0;
        bool IsEndDay = false;
        intlastDay = CalcEndDayOfMonth(DateIn.Year, DateIn.Month);
        if (intlastDay == DateIn.Day)
        {
            IsEndDay = true;
        }
        else
        {
            IsEndDay = false;
        }
        return IsEndDay;
    }
