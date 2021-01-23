            int year = 2014;
            for (int month = 1; month <= 12; month++)
            {
                for (int day = 1; day <= 31; day++)
                {
                    if (day <= DateTime.DaysInMonth(year, month))
                    {
                        DateTime weekday = new DateTime(year, month, day);
                        <td>
                            @{
                                <span>@weekday</span>
                                <br />
                            }
                        </td>
                    }
                }
            }
