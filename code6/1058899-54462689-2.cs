    <select class="combo">
        @{
            var currnt = DateTime.Now.Month;
            var counter = currnt;
            for (int i = 1; i < 13; i++)
            {
                if (counter > 12)
                {
                    counter = 1;
                }
                // option 1 - month number:
                <option>@counter</option>
                // option 2 - month name:
                // <option>@DivisionPortal.Models.Helpers.TimeHelpers.GetMonthName((byte)counter)</option>
                counter++;
            }
        }
    </select>
