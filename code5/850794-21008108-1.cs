            int year = 2014;
            for (int month = 1; month <= 12; month++)
            {
                int daysInMonth = DateTime.DaysInMonth(year, month)
                for (int day = 1; day <= daysInMonth; day++)
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
